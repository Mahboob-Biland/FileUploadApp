namespace FileUploadApp.Store
{
    public interface IFileInfoData
    {
        int Id { get; set; }

        string FilePath { get; set; }

        string FileName { get; }

        string BannedWords { get; set; }

    }
}
