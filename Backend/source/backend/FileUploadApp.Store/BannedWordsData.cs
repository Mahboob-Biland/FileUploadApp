namespace FileUploadApp.Store
{
    public class BannedWordsData : IBannedWordsData
    {
        public int Id { get; set; }

        public string WordText { get; set; }
    }
}
