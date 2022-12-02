using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Assignment1.Pages;

namespace Assignment1
{
    public class GameRepository
    {
        SQLiteConnection conn;
        public GameRepository(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Records>();
        }
        public void AddNewGame(string name, string type, string year, string version)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = conn.Insert(new Records() { Name = name, Type = type, Year = year, Version = version });

                StatusMessage = string.Format("{0} record(s) added [Name:{1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }
        public string StatusMessage { get; set; }

        public void DeleteGame()
        {
            Records temp = conn.Table<Records>().First();
            conn.Table<Records>().Delete();
        }

        public List<Records> GetAllGame()
        {
            try
            {
                return conn.Table<Records>().ToList();
            }catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Records>();
        }
    }
}
