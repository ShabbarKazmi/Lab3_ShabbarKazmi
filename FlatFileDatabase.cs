﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab3_ShabbarKazmi
{
    /// <summary>
    /// This is the database class, currently a FlatFileDatabase
    /// </summary>
    public class FlatFileDatabase : IDatabase
    {
        String path = "";
        String filename = "clues.json";

        /// <summary>
        /// A local version of the database, we *might* want to keep this in the code and merely
        /// adjust it whenever Add(), Delete() or Edit() is called
        /// Alternatively, we could delete this, meaning we will reach out to bit.io for everything
        /// What are the costs of that?
        /// There are always tradeoffs in software engineering.
        /// </summary>
        ObservableCollection<Microsoft.Maui.Controls.Entry> entries = new ObservableCollection<Microsoft.Maui.Controls.Entry>();

        JsonSerializerOptions options;

        public FlatFileDatabase()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            path = $"{appDataPath}/{filename}"; // /data/user/0/com.companyname.basicdotnetmauiproject/files/clues.json
            Console.WriteLine($"We've got your path right here: {path}");

            GetEntries();
            options = new JsonSerializerOptions { WriteIndented = true };
        }


        /// <summary>
        /// Adds an entry to the database
        /// </summary>
        /// <param name="entry">the entry to add</param>
        public void AddEntry(Microsoft.Maui.Controls.Entry entry)
        {
            try
            {
                entry.Id = entries.Count + 1;
                entries.Add(entry);

                string jsonString = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(path, jsonString);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while adding entry: {0}", ioe);
            }
        }


        /// <summary>
        /// Finds a specific entry
        /// </summary>
        /// <param name="id">id to find</param>
        /// <returns>the Entry (if available)</returns>
        public Microsoft.Maui.Controls.Entry FindEntry(int id)
        {
            foreach (Microsoft.Maui.Controls.Entry entry in entries)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }
            return null;
        }

        /// <summary>
        /// Deletes an entry 
        /// </summary>
        /// 
        /// <param name="entry">An entry, which is presumed to exist</param>
        public bool DeleteEntry(Microsoft.Maui.Controls.Entry entry)
        {
            try
            {
                var result = entries.Remove(entry);
                string jsonString = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while deleting entry: {0}", ioe);
            }
            return false;
        }

        /// <summary>
        /// Edits an entry
        /// </summary>
        /// <param name="replacementEntry"></param>
        /// <returns>true if editing was successful</returns>
        public bool EditEntry(Microsoft.Maui.Controls.Entry replacementEntry)
        {
            foreach (Microsoft.Maui.Controls.Entry entry in entries) // iterate through entries until we find the Entry in question
            {
                if (entry.Id == replacementEntry.Id) // found it
                {
                    entry.Answer = replacementEntry.Answer;
                    entry.Clue = replacementEntry.Clue;
                    entry.Difficulty = replacementEntry.Difficulty;
                    entry.Date = replacementEntry.Date;         // change it then write it out

                    try
                    {
                        string jsonString = JsonSerializer.Serialize(entries, options);
                        File.WriteAllText(path, jsonString);
                        return true;
                    }
                    catch (IOException ioe)
                    {
                        Console.WriteLine("Error while replacing entry: {0}", ioe);
                    }

                }
            }
            return false;
        }

        /// <summary>
        /// Retrieves all the entries
        /// </summary>
        /// <returns>all of the entries</returns>
        public ObservableCollection<Microsoft.Maui.Controls.Entry> GetEntries()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
                entries = new ObservableCollection<Microsoft.Maui.Controls.Entry>();
                return entries;
            }

            string jsonString = File.ReadAllText(path);
            if (jsonString.Length > 0)
            {
                entries = JsonSerializer.Deserialize<ObservableCollection<Microsoft.Maui.Controls.Entry>>(jsonString);
            }
            return entries;
        }
    }
}
