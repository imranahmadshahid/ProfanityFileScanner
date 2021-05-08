using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProfanityScanner.Business.DomainModels;

namespace ProfanityScanner.Business.Infrastructure
{
    public interface IFileHandler
    {
        Task<ProfanityFileResponse> ProcessFile(IFormFile file);
    }
}
