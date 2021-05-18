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
        private readonly IBannedWords _bannedWordsRepository;
        public FileManagement(IFilesRepository fileRepository, IBannedWords bannedWordsRepository)
        {
            _fileRepository = fileRepository;
            _bannedWordsRepository = bannedWordsRepository;
        }

        /// <summary>
        /// Insert file info
        /// </summary>
        /// <param name="filePath">path of the file</param>
        /// <returns>List of banned words if file has any</returns>
        public async Task<IEnumerable<string>> InsertFileInfo(string filePath)
        {
            List<string> bannedWords = new List<string>();
            using (StreamReader file = new StreamReader(filePath))
            {
                IEnumerable<IBannedWordsData> allBannedWords = await _bannedWordsRepository.GetBannedWordsAsync();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    foreach (IBannedWordsData word in allBannedWords)
                    {
                        if (!bannedWords.Contains(word.WordText) && line.IndexOf(word.WordText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            bannedWords.Add(word.WordText);
                        }
                    }
                }
            }
            await _fileRepository.InsertFileInfo(filePath, string.Join(",", bannedWords));
            return bannedWords;
        }

        /// <summary>
        /// Get list of all files
        /// </summary>
        /// <returns>List for files</returns>
        public async Task<IEnumerable<IFileInfoData>> GetFileInfoAsync()
        {
            return await _fileRepository.GetFileInfoAsync();
        }

        /// <summary>
        /// Deleted file from DB
        /// </summary>
        /// <param name="id">Id of file</param>
        /// <returns>Bool if operation is successfull</returns>
        public bool DeleteFileInfo(int id)
        {
            //TODo : Delete file from disk as well
            return _fileRepository.DeleteFileInfo(id);
        }

    }
}
