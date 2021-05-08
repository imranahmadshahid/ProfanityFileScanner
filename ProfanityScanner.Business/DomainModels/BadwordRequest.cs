using System.ComponentModel.DataAnnotations;

namespace ProfanityScanner.Business.DomainModels
{
    public class BadwordRequest
    {
        [Required(ErrorMessage = "Word is required in the Request",AllowEmptyStrings = false)]
        public string Word { get; set; }
    }
}
