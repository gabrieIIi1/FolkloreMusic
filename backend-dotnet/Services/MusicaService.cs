using backend_dotnet.Data;
using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Services
{
    public class MusicaService
    {
        private readonly AppDbContext _context;

        public MusicaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Musica>> ListarAsync()
        {
            return await _context.Musicas.ToListAsync();
        }

        public async Task<Musica> CriarAsync(Musica musica)
        {
            _context.Musicas.Add(musica);

            await _context.SaveChangesAsync();

            return musica;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var musica = await _context.Musicas.FindAsync(id);

            if (musica == null)
                return false;

            _context.Musicas.Remove(musica);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}