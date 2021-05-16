using FileUploadApp.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.File
{
    public interface IBannedWords
    {
        Task<bool> InsertBannedWord(string wordText);

        Task<bool> UpdateBannedWord(IBannedWordsData bannedWord);

        Task<bool> DeleteBannedWord(int id);

        Task<IEnumerable<IBannedWordsData>> GetBannedWordsAsync();

    }
}
