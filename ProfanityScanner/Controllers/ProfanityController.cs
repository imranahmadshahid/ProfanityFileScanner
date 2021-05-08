using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProfanityScanner.Business.DomainModels;
using ProfanityScanner.Business.Infrastructure;

namespace ProfanityScanner.Controllers
{
    [ApiController]
    public class ProfanityController : ControllerBase
    {
        private IBanWordRepository _badWordRepository;
        public ProfanityController(IBanWordRepository badWordRepository)
        {
            _badWordRepository = badWordRepository;
        }

        [HttpPost]
        [Route("api/v1/bannedword/add")]
        public ActionResult AddBannnedWord(BadwordRequest request)
        {
            try
            {
                var response = _badWordRepository.AddBannedWord(request?.Word);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }

        }

        [HttpPost]
        [Route("api/v1/bannedword/delete")]
        public ActionResult DeleteBannedWord(BadwordRequest request)
        {
            try
            {
                var response = _badWordRepository.RemoveBannedWord(request?.Word);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }

        }

        [HttpGet]
        [Route("api/v1/bannedword")]
        public ActionResult GetBannedWords()
        {
            try
            {
                var response = _badWordRepository.GetBannedWords();
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }

        }
    }
}