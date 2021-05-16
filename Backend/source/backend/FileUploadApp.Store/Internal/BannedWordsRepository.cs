using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadApp.Store.Internal
{
    internal class BannedWordsRepository : IBannedWordsRepository
    {
        public static string DbFile => Path.GetFullPath(System.AppContext.BaseDirectory + "..\\..\\..\\..\\..\\..\\..\\" + Constants.DbName);

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
                    using (SqliteCommand cmd = new SqliteCommand("INSERT INTO bannedWords (wordText) VALUES (@wordText)", cnn))
                    {
                        cmd.Parameters.Add(new SqliteParameter("@wordText", wordText));
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODo : Implement exception handling
                string test = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Update banned word to database.
        /// </summary>
        /// <param name="wordText">Text of banned word</param>
        /// <returns>bool result of update operation</returns>
        public async Task<bool> UpdateBannedWord(IBannedWordsData bannedWord)
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
                    using (SqliteCommand cmd = new SqliteCommand("Update bannedWords set wordText =@wordText where id = @id", cnn))
                    {
                        cmd.Parameters.Add(new SqliteParameter("@wordText", bannedWord.WordText));
                        cmd.Parameters.Add(new SqliteParameter("@id", bannedWord.Id));
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODo : Implement exception handling
                string test = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete banned word from database.
        /// </summary>
        /// <param name="id">id of banned word</param>
        /// <returns>bool result of delete operation</returns>
        public async Task<bool> DeleteBannedWord(int id)
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
                    using (SqliteCommand cmd = new SqliteCommand("Delete from bannedWords where id = @id", cnn))
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

        /// <summary>
        /// Get IEnumerable of all banned words.
        /// </summary>
        /// <returns>IEnumerable of IBannedWordsData</returns>
        public async Task<IEnumerable<IBannedWordsData>> GetBannedWordsAsync()
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
                    using (SqliteCommand cmd = new SqliteCommand($"SELECT id, wordText FROM bannedWords", cnn))
                    {
                        using (SqliteDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            List<IBannedWordsData> IdsList = new List<IBannedWordsData>();
                            while (reader.Read())
                            {
                                IdsList.Add(new BannedWordsData() { Id = reader.GetInt16(0), WordText = reader.GetString(1) });
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

    }
}
