using System.Collections.Generic;

namespace ProfanityScanner.Business.Infrastructure
{
    public interface IBanWordRepository
    {
        List<string> GetBannedWords();
        bool AddBannedWord(string word);
        bool RemoveBannedWord(string word);
    }
}
