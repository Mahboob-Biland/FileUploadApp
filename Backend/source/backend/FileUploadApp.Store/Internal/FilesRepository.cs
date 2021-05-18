using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadApp.Store.Internal
{
    internal class FilesRepository : IFilesRepository
    {
        public static string DbFile => Path.GetFullPath(System.AppContext.BaseDirectory + "..\\..\\..\\..\\..\\..\\" + Constants.DbName);

        public static SqliteConnection DbConnection()
        {
            return new SqliteConnection("Data Source=" + DbFile);
        }

        /// <summary>
        /// Store path and name of new uploaded path in database, also any banned word it contain.
        /// </summary>
        /// <param name="filePath">File full path with name.</param>
        /// <param name="bannedWords">Any banned word the file has.</param>
        /// <returns></returns>
        public async Task<bool> InsertFileInfo(string filePath, string bannedWords)
        {
            if (!File.Exists(DbFile))
            {
                return false;
            }

            try
            {
                using (SqliteConnection cnn = DbConnection())
                {
                    await cnn.OpenAsync();
                    using (SqliteCommand cmd = new SqliteCommand("INSERT INTO fileInfo (filePath,bannedWords) VALUES (@filePath,@bannedWords)", cnn))
                    {
                        cmd.Parameters.Add(new SqliteParameter("@filePath", filePath));
                        cmd.Parameters.Add(new SqliteParameter("@bannedWords", bannedWords));
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODo : Implement exception handling
                throw ex;
            }
        }


        /// <summary>
        /// Get IEnumerable of all file info stored in DB.
        /// </summary>
        /// <returns>IEnumerable of IFileInfoData</returns>
        public async Task<IEnumerable<IFileInfoData>> GetFileInfoAsync()
        {
            if (!File.Exists(DbFile))
            {
                return null;
            }

            try
            {
                using (SqliteConnection cnn = DbConnection())
                {
                    await cnn.OpenAsync();
                    using (SqliteCommand cmd = new SqliteCommand($"SELECT id, bannedWords,filePath FROM fileInfo", cnn))
                    {
                        using (SqliteDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            List<IFileInfoData> fileInfoList = new List<IFileInfoData>();
                            while (reader.Read())
                            {
                                fileInfoList.Add(new FileInfoData() { Id = reader.GetInt16(0), BannedWords = reader.GetString(1), FilePath = reader.GetString(2) });
                            }
                            return fileInfoList;
                        }
                    }
                }
            }
            catch
            {
                //TODo : Implement exception handling
                return null;
            }
        }


        /// <summary>
        /// Delete file info from database.
        /// </summary>
        /// <param name="id">Id of file being deleted</param>
        /// <returns>bool result of delete operation</returns>
        public bool DeleteFileInfo(int id)
        {
            if (!File.Exists(DbFile))
            {
                return false;
            }

            try
            {
                using (SqliteConnection cnn = DbConnection())
                {
                    cnn.OpenAsync();
                    using (SqliteCommand cmd = new SqliteCommand("Delete from fileInfo where id = @id", cnn))
                    {
                        cmd.Parameters.Add(new SqliteParameter("@id", id));
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODo : Implement exception handling
                throw ex;
            }
        }
    }
}
