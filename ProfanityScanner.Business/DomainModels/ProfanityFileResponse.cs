namespace ProfanityScanner.Business.DomainModels
{
    public class ProfanityFileResponse
    {
        public bool IsAppropriate { get; set; }
        public int BadWordCount { get; set; }
    }
}
