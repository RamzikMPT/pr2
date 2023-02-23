using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WpfApp2
{


   
    public class deserser
    {
        public static void sohranenie(List<Note> zapis)
        {
            File.WriteAllText("zametki.json", JsonConvert.SerializeObject(zapis));
        }

        public static List<Note> LoadNotes(DateTime date = default)
        {
            List<Note> zapis = new List<Note>();
            try
            {
                List<Note> new_zapis = JsonConvert.DeserializeObject<List<Note>>(File.ReadAllText("zametki.json"));
                foreach (Note note in new_zapis)
                {
                    if (note.date == date || date == default)
                        zapis.Add(note);
                }
            }
            catch
            {
                zapis = new List<Note>();
                File.WriteAllText("zametki.json", JsonConvert.SerializeObject(zapis));
            }
            return zapis;
        }

        public static void AddNote(Note note)
        {
            List<Note> zapis = LoadNotes();
            zapis.Add(note);
            sohranenie(zapis);
        }
    }

}
