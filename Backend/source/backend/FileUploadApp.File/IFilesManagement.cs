using FileUploadApp.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.File
{
    public interface IFilesManagement
    {

        Task<IEnumerable<string>> InsertFileInfo(string filePath);

        Task<IEnumerable<IFileInfoData>> GetFileInfoAsync();

        bool DeleteFileInfo(int id);

    }
}
