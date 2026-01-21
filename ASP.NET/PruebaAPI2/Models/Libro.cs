namespace PruebaAPI2.Models
{
    public class Libro
    {
        public int Id { get; set; } = Random.Shared.Next(0, 100000);
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime publicacion { get; set; }
    }
}
