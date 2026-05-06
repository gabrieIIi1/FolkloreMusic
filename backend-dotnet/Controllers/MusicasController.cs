using Microsoft.AspNetCore.Mvc;
using backend_dotnet.Services;
using backend_dotnet.Models;
using backend_dotnet.DTOs;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicasController : ControllerBase
    {
        private readonly MusicaService _service;

        public MusicasController(MusicaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var musicas = await _service.ListarAsync();

            return Ok(musicas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(MusicaCreateDTO dto)
        {
            var musica = new Musica
            {
                Titulo = dto.Titulo,
                Artista = dto.Artista,
                Genero = dto.Genero,
                CapaUrl = dto.CapaUrl,
                LinkUrl = dto.LinkUrl,
            };

            var resultado = await _service.CriarAsync(musica);

            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletou = await _service.DeletarAsync(id);

            if (!deletou)
                return NotFound();

            return NoContent();
        }
    }
}