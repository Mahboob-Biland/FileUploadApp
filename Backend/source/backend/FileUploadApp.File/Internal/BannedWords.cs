using FileUploadApp.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.File.Internal
{
    internal class BannedWords : IBannedWords
    {
        private readonly IBannedWordsRepository _bannedWordsRepository;
        public BannedWords(IBannedWordsRepository bannedWordsRepository)
        {
            _bannedWordsRepository = bannedWordsRepository;
        }
        public async Task<IEnumerable<IBannedWordsData>> GetBannedWordsAsync()
        {
            return await _bannedWordsRepository.GetBannedWordsAsync();
        }

        public async Task<bool> InsertBannedWord(string wordText)
        {
            return await _bannedWordsRepository.InsertBannedWord(wordText);
        }

        public async Task<bool> UpdateBannedWord(IBannedWordsData bannedWord)
        {
            return await _bannedWordsRepository.UpdateBannedWord(bannedWord);
        }

        public async Task<bool> DeleteBannedWord(int id)
        {
            return await _bannedWordsRepository.DeleteBannedWord(id);
        }

    }
}
