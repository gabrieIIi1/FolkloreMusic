using backend_dotnet.Data;
using backend_dotnet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<MusicaService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=musicas.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("React",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("React");

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();