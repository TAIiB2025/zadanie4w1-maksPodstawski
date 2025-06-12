using WebAPI.DTO;
using WebAPI.Model;

namespace WebAPI.Service
{
    public class KsiazkaService : IKsiazkaService
    {

        private static int IdGen = 1;
        private static readonly List<Ksiazka> ksiazkaDbSet = [
            new Ksiazka() {
                Id = IdGen++,
                Tytul = "Zbrodnia i kara",
                Autor = "Fiodor Dostojewski",
                Gatunek = "romans",
                Rok = 1866
            },
            new Ksiazka() {
                Id = IdGen++,
                Tytul = "Pan Tadeusz",
                Autor = "Adam Mickiewicz",
                Gatunek = "romans",
                Rok = 1834
            },
            new Ksiazka() {
                Id = IdGen++,
                Tytul = "Rok 1984",
                Autor = "George Orwell",
                Gatunek = "dystopia",
                Rok = 1949
            },
            new Ksiazka() {
                Id = IdGen++,
                Tytul = "Wiedźmin: Ostatnie życzenie",
                Autor = "Andrzej Sapkowski",
                Gatunek = "fantasy",
                Rok = 1993
            },
            new Ksiazka() {
                Id = IdGen++,
                Tytul = "Duma i uprzedzenie",
                Autor = "Jane Austen",
                Gatunek = "romans",
                Rok = 1813
            }
        ];

        public void DeleteByID(int id)
        {
            var ksiazka = ksiazkaDbSet.FirstOrDefault(k => k.Id == id);
            if (ksiazka != null)
            {
                ksiazkaDbSet.Remove(ksiazka);
            }
        }

        public IEnumerable<Ksiazka> Get()
        {
            return ksiazkaDbSet;
        }

        public IEnumerable<Ksiazka> GetByTitle(string searchPhrase)
        {
            if (string.IsNullOrWhiteSpace(searchPhrase))
                return ksiazkaDbSet;

            return ksiazkaDbSet.Where(k => 
                k.Tytul.Contains(searchPhrase, StringComparison.OrdinalIgnoreCase));
        }

        public Ksiazka? GetByID(int id)
        {
            var ksiazka = ksiazkaDbSet.FirstOrDefault(k => k.Id == id);
            if (ksiazka == null) return null;

            return ksiazka;
        }

        public void Post(KsiazkaDTO ksiazkaPostDTO)
        {
            var ksiazka = new Ksiazka
            {
                Id = IdGen++,
                Tytul = ksiazkaPostDTO.Tytul,
                Autor = ksiazkaPostDTO.Autor,
                Gatunek = ksiazkaPostDTO.Gatunek.ToLower(),
                Rok = ksiazkaPostDTO.Rok
            };

            ksiazkaDbSet.Add(ksiazka);
        }

        public void Update(Ksiazka ksiazka)
        {
            var existing = ksiazkaDbSet.FirstOrDefault(k => k.Id == ksiazka.Id);
            if (existing == null) return;

            existing.Tytul = ksiazka.Tytul;
            existing.Autor = ksiazka.Autor;
            existing.Gatunek = ksiazka.Gatunek.ToLower();
            existing.Rok = ksiazka.Rok;
        }
    }
}
