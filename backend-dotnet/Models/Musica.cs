namespace backend_dotnet.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Artista { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string CapaUrl { get; set; } = string.Empty;
        public string LinkUrl { get; set; } = string.Empty;
    }
}