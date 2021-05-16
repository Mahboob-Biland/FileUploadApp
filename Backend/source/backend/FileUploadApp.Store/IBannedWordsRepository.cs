using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.Store
{
    public interface IBannedWordsRepository
    {
        Task<bool> InsertBannedWord(string wordText);

        Task<bool> UpdateBannedWord(IBannedWordsData bannedWord);

        Task<bool> DeleteBannedWord(int id);

        Task<IEnumerable<IBannedWordsData>> GetBannedWordsAsync();

    }
}
