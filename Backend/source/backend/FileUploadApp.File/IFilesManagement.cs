using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadApp.File
{
    public interface IFilesManagement
    {
        Task<bool> InsertBannedWord(string wordText);

        Task<IEnumerable<string>> GetBannedWordsAsync();

        Task<string> UploadFile(Stream filefileContent);

    }
}
