using FileUploadApp.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.File.Internal
{
    internal class FileManagement : IFilesManagement
    {
        private readonly IFilesRepository _fileRepository;
        public FileManagement(IFilesRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<IEnumerable<string>> InsertFileInfo(string filePath)
        {
            List<string> bannedWords = new List<string>() { "Test1", "Test2" };
            await _fileRepository.InsertFileInfo(filePath, string.Join(",", bannedWords));

            return bannedWords;
        }

        public async Task<IEnumerable<IFileInfoData>> GetFileInfoAsync()
        {
            return await _fileRepository.GetFileInfoAsync();
        }

        public bool DeleteFileInfo(int id)
        {
            return _fileRepository.DeleteFileInfo(id);
        }

    }
}
