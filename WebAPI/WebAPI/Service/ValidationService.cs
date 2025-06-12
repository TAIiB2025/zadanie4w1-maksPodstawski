using WebAPI.DTO;
using WebAPI.Model;

namespace WebAPI.Service
{
    public class ValidationService : IValidationService
    {
        private static readonly List<string> PoprawneGatunki = new()
        {
            "Fantasy",
            "Romans",
            "Dystopia"
        };

        public (bool isValid, string? errorMessage) ValidateBook(KsiazkaDTO ksiazka)
        {
            if (string.IsNullOrWhiteSpace(ksiazka.Tytul))
            {
                return (false, "Tytuł jest wymagany");
            }

            if (ksiazka.Tytul.Length > 100)
            {
                return (false, "Tytuł nie może być dłuższy niż 100 znaków");
            }

            if (string.IsNullOrWhiteSpace(ksiazka.Gatunek))
            {
                return (false, "Gatunek jest wymagany");
            }

            if (!PoprawneGatunki.Contains(ksiazka.Gatunek, StringComparer.OrdinalIgnoreCase))
            {
                return (false, "Nieprawidłowy gatunek. Dozwolone wartości to: Fantasy, Romans, Dystopia");
            }

            if (ksiazka.Rok > 2025)
            {
                return (false, "Rok nie może być większy niż 2025");
            }

            return (true, null);
        }
    }
} 