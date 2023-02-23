using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WpfApp2
{
    public class Note
    {
        public int nomer;
        public DateTime date;
        public string nazvanie;
        public string description;
        public Note(int nomer, string nazvanie, string description, DateTime date)
        {
            this.nazvanie = nazvanie;
            this.description = description;
            this.date = date;
            this.nomer = nomer;
        }

    }
     public class Timetable
     {
         public List<Note> zametkitoday;
         public DateTime selectedDate;
         public int selectedTaskId = -1;
         public List<Note> vsezametki;
         public Timetable(DateTime date)
         {
             this.zametkitoday = deserser.LoadNotes(date);
             this.vsezametki = deserser.LoadNotes(default);
             selectedDate = date;
         }
         public void udalenie(int id = -1, int todayId = -1)
         {
            
            if (todayId != -1)
                id = this.zametkitoday[todayId].nomer;
            List<Note> newNotes = new List<Note>(this.vsezametki);
            newNotes.RemoveAll(note => note.nomer == id);
            this.vsezametki = newNotes;
             obnavlenie();
             obnova();
         }


         public void nowayazapiska(string title, string desc, DateTime date)
         {

             Note note = new Note(this.vsezametki.Count, title, desc, date);
             this.vsezametki.Add(note);
             deserser.sohranenie(this.vsezametki);
             this.obnavlenie();
         }
   



    public void obnavlenie()
        {
            this.zametkitoday = deserser.LoadNotes(this.selectedDate);
        }
        public void obnova()
        {
            deserser.sohranenie(this.vsezametki);
        }
    }

}