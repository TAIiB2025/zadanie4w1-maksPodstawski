using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Model;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsiazkaController : ControllerBase
    {

        private readonly IKsiazkaService _ksiazkaService;
        private readonly IValidationService _validationService;


        public KsiazkaController(IKsiazkaService ksiazkaService, IValidationService validationService)
        {
            _ksiazkaService = ksiazkaService;
            _validationService = validationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ksiazka>> GetKsiazki()
        {
            var ksiazki = _ksiazkaService.Get();
            return Ok(ksiazki);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Ksiazka>> GetKsiazkiByTitle([FromQuery] string searchPhrase)
        {
            var ksiazki = _ksiazkaService.GetByTitle(searchPhrase);
            return Ok(ksiazki);
        }

        [HttpGet("{id}")]
        public ActionResult<KsiazkaDTO> GetKsiazkaById(int id)
        {
            var ksiazka = _ksiazkaService.GetByID(id);
            if (ksiazka == null)
                return NotFound();

            return Ok(ksiazka);
        }

        [HttpPost]
        public IActionResult PostKsiazka([FromBody] KsiazkaDTO ksiazkaDto)
        {
            var (isValid, errorMessage) = _validationService.ValidateBook(ksiazkaDto);
            if (!isValid)
            {
                return BadRequest(errorMessage);
            }

            _ksiazkaService.Post(ksiazkaDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateKsiazka(int id, [FromBody] Ksiazka ksiazka)
        {
            if (id != ksiazka.Id)
                return BadRequest("ID nie pasuje do obiektu");

            var ksiazkaDto = new KsiazkaDTO
            {
                Tytul = ksiazka.Tytul,
                Autor = ksiazka.Autor,
                Gatunek = ksiazka.Gatunek,
                Rok = ksiazka.Rok
            };

            var (isValid, errorMessage) = _validationService.ValidateBook(ksiazkaDto);
            if (!isValid)
            {
                return BadRequest(errorMessage);
            }

            _ksiazkaService.Update(ksiazka);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKsiazka(int id)
        {
            _ksiazkaService.DeleteByID(id);
            return NoContent();
        }
    }
}
