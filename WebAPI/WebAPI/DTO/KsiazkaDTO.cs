using WebAPI.Model;
using System.Text.Json.Serialization;

namespace WebAPI.DTO
{
    public record KsiazkaDTO
    {
        public required string Tytul { get; init; }
        public required string Autor { get; init; }
        public required string Gatunek { get; init; }
        public int Rok { get; init; }
    }
}
