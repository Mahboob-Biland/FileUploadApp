using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadApp.Store.Internal
{
    internal class FilesRepository : IFilesRepository
    {
        public static string DbFile => Path.GetFullPath(System.AppContext.BaseDirectory+ "..\\..\\..\\..\\..\\..\\" + Constants.DbName);

        public static SqliteConnection DbConnection()
        {
            return new SqliteConnection("Data Source=" + DbFile);
        }

        /// <summary>
        /// Add new banned word to database.
        /// </summary>
        /// <param name="wordText">Text of banned word</param>
        /// <returns>bool result of insert operation</returns>
        public async Task<bool> InsertBannedWord(string wordText)
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
                    using (SqliteCommand cmd = new SqliteCommand("INSERT INTO bannedWords (wordText) VALUES (?)", cnn))
                    {
                        cmd.Parameters.Add(wordText);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch
            {
                //TODo : Implement exception handling
                return false;
            }
        }

        /// <summary>
        /// Get IEnumerable of all banned words.
        /// </summary>
        /// <returns>IEnumerable of strings</returns>
        public async Task<IEnumerable<string>> GetBannedWordsAsync()
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
                    using (SqliteCommand cmd = new SqliteCommand($"SELECT wordText FROM bannedWords", cnn))
                    {
                        using (SqliteDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            List<string> IdsList = new List<string>();
                            while (reader.Read())
                            {
                                IdsList.Add(reader.GetString(0));
                            }
                            return IdsList;
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
                    using (SqliteCommand cmd = new SqliteCommand("INSERT INTO fileInfo (filePath,bannedWords) VALUES (?,?)", cnn))
                    {
                        cmd.Parameters.Add(filePath);
                        cmd.Parameters.Add(bannedWords);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch
            {
                //TODo : Implement exception handling
                return false;
            }
        }
    }
}
