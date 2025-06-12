using WebAPI.DTO;

namespace WebAPI.Model
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public required string Tytul { get; set; }
        public required string Autor { get; set; }
        public required string Gatunek { get; set; }
        public int Rok {  get; set; }
    }
}
