using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.Store
{
    public interface IFilesRepository
    {
        Task<bool> InsertBannedWord(string wordText);

        Task<IEnumerable<string>> GetBannedWordsAsync();

        Task<bool> InsertFileInfo(string filePath,string bannedWords);

    }
}
