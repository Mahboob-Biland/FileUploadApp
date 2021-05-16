using System.IO;

namespace FileUploadApp.Store.Internal
{
    internal class FileInfoData : IFileInfoData
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public string FileName => string.IsNullOrEmpty(FilePath) ? string.Empty : Path.GetFileName(FilePath);

        public string BannedWords { get; set; }
    }
}
