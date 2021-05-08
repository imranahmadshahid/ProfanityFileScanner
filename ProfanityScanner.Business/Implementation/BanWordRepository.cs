using System;
using System.Collections.Generic;
using System.Linq;
using ProfanityScanner.Business.Database;
using ProfanityScanner.Business.Infrastructure;

namespace ProfanityScanner.Business.Implementation
{
    public class BanWordRepository : IBanWordRepository
    {
        private ProfanityScannerContext _dbContext;
        public BanWordRepository(ProfanityScannerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<string> GetBannedWords()
        {
            return _dbContext.BadWords.Select(x => x.Word).ToList();
        }

        public bool AddBannedWord(string word)
        {
            if (_dbContext.BadWords.Any(x => x.Word.Equals(word)))
            {
                throw new Exception($"{word} Word Already Exists");
            }
            _dbContext.BadWords.Add(new BadWords() { Word = word });
            _dbContext.SaveChanges();
            return true;
        }

        public bool RemoveBannedWord(string word)
        {
            var wordToDelete =
                _dbContext.BadWords.FirstOrDefault(
                    x => x.Word.Equals(word));
            if (wordToDelete==null)
            {
                throw new Exception($"{word} Word deosn't exist");
            }

            _dbContext.BadWords.Remove(wordToDelete);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
