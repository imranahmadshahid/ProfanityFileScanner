using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProfanityScanner.Business.DomainModels;
using ProfanityScanner.Business.Infrastructure;

namespace ProfanityScanner.Business.Implementation
{
    public class FileHandler : IFileHandler
    {
        private string basePath;
        private IBanWordRepository _badWordRepository;
        public FileHandler(IBanWordRepository badWordRepository)
        {
            _badWordRepository = badWordRepository;
            var currentAssembly = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty;
            basePath = Path.Combine(currentAssembly, "Files");
        }
        public async Task<ProfanityFileResponse> ProcessFile(IFormFile file)
        {
            await SaveFile(file);
            return ScanFile(file);
        }

        private async Task SaveFile(IFormFile file)
        {
            var path = Path.Combine(basePath, file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

       
        private ProfanityFileResponse ScanFile(IFormFile file)
        {
            var fileText = File.ReadAllText(Path.Combine(basePath, file.FileName));
            var badWords = _badWordRepository.GetBannedWords();
            int badWordCount = 0;
            foreach (var word in fileText.Split(' '))
            {
                if(badWords.Any(x=> x.Equals(word,StringComparison.InvariantCultureIgnoreCase)))
                    badWordCount++;
            }

            return new ProfanityFileResponse
            {
                IsAppropriate = badWordCount == 0,
                BadWordCount = badWordCount
            };
        }
    }
}
