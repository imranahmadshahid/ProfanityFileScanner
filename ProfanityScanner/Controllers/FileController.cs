using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfanityScanner.Business.Infrastructure;

namespace ProfanityScanner.Controllers
{
    [ApiController]
    public class FileController : ControllerBase
    {


        private readonly IFileHandler _fileHandler;

        public FileController(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        [HttpPost("api/v1/processfile")]
        public async Task<IActionResult> Processfile(IFormFile file)
        {
            try
            {
                var response = await _fileHandler.ProcessFile(file);
                return Ok(response);
            }
            catch(Exception ex )
            {
                return BadRequest();
            }
        }
    }
}
