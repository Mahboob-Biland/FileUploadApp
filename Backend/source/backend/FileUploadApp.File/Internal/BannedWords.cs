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

        /// <summary>
        /// Get All Banned words from database.
        /// </summary>
        /// <returns>Return list of string of banned words</returns>
        public async Task<IEnumerable<IBannedWordsData>> GetBannedWordsAsync()
        {
            return await _bannedWordsRepository.GetBannedWordsAsync();
        }

        /// <summary>
        /// Insert new banned word in database.
        /// </summary>
        /// <param name="wordText">Banned word text</param>
        /// <returns>Result of operation as bool</returns>
        public async Task<bool> InsertBannedWord(string wordText)
        {
            return await _bannedWordsRepository.InsertBannedWord(wordText);
        }

        /// <summary>
        /// Update banned word text
        /// </summary>
        /// <param name="bannedWord">Banned word text</param>
        /// <returns>Result of operation as bool</returns>
        public async Task<bool> UpdateBannedWord(IBannedWordsData bannedWord)
        {
            return await _bannedWordsRepository.UpdateBannedWord(bannedWord);
        }

        /// <summary>
        /// Delete Banned word
        /// </summary>
        /// <param name="id">Id of banned word</param>
        /// <returns>Result of operation as bool</returns>
        public async Task<bool> DeleteBannedWord(int id)
        {
            return await _bannedWordsRepository.DeleteBannedWord(id);
        }

    }
}
