using WebAPI.DTO;

namespace WebAPI.Service
{
    public interface IValidationService
    {
        (bool isValid, string? errorMessage) ValidateBook(KsiazkaDTO ksiazka);
    }
}
