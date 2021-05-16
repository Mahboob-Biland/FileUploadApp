using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.Store
{
    public interface IFilesRepository
    {
        Task<bool> InsertFileInfo(string filePath, string bannedWords);

        Task<IEnumerable<IFileInfoData>> GetFileInfoAsync();

        bool DeleteFileInfo(int id);

    }
}
