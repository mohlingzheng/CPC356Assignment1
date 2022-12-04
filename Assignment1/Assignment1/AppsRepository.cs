using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Assignment1.Pages;
using System.Linq;
using Xamarin.Forms;

namespace Assignment1
{
    public class AppsRepository
    {
        SQLiteConnection conn;
        public AppsRepository(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Records>();
            //AddDefaultList();
        }
        public void AddNewApps(string name, string type, string year, string version)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = conn.Insert(new Records() { Name = name, Type = type, Year = "Year " + year, Version = "Ver." + version });

                StatusMessage = string.Format("{0} record(s) added [Name:{1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }
        public string StatusMessage { get; set; }

        public void DeleteGame(String target)
        {
            try
            {;
                Records record = conn.Get<Records>(Int16.Parse(target));
                conn.Delete(record);
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            
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
        /*
        private void AddDefaultList()
        {
            AddNewGame("WhatsApp", "Social Media", "2009", "2.22");
            AddNewGame("Telegram", "Social Media", "2013", "9.1.6");
            AddNewGame("Pokémon GO", "Game", "2016", "6.0.1");
            AddNewGame("Netflix", "Entertainment", "1997", "7.1.2");
        }
        */
    }
}
