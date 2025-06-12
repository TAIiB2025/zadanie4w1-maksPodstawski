using WebAPI.DTO;
using WebAPI.Model;

namespace WebAPI.Service
{
    public interface IKsiazkaService
    {
        public IEnumerable<Ksiazka> Get();
        public IEnumerable<Ksiazka> GetByTitle(string searchPhrase);
        public Ksiazka? GetByID(int id);
        public void Post(KsiazkaDTO ksiazkaPostDTO);
        public void DeleteByID(int id);
        public void Update(Ksiazka ksiazka);
    }
}
