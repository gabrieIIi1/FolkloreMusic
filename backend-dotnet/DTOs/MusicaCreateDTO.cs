namespace backend_dotnet.DTOs
{
    public class MusicaCreateDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Artista { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string CapaUrl { get; set; } = string.Empty;
        public string LinkUrl { get; set; } = string.Empty;
    }
}