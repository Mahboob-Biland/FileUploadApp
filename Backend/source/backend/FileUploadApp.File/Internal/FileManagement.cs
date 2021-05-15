using FileUploadApp.Store;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IEnumerable<string>> GetBannedWordsAsync()
        {
            return await _fileRepository.GetBannedWordsAsync();
        }

        public async Task<bool> InsertBannedWord(string wordText)
        {
            return await _fileRepository.InsertBannedWord(wordText);
        }

        public Task<string> UploadFile(Stream filefileContent)
        {
            throw new NotImplementedException();
        }
    }
}
