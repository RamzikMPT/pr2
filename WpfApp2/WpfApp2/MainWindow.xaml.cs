using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Timetable raspisanie;
        public static DateTime selectedDate = DateTime.Today;

        public MainWindow()
        {
            InitializeComponent();
            raspisanie = new Timetable(selectedDate);
            izmspiskazametok();
            DATA.SelectedDate = selectedDate;
        }
        

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            string title = NAZVANIE.Text;
            string desc = OPISANIE.Text;
            raspisanie.nowayazapiska(title, desc, selectedDate);
            izmspiskazametok();
        }
        public void izmspiskazametok()
        {
            selectedDate = raspisanie.selectedDate;
            raspisanie.obnavlenie();
            ZAMETKI.Items.Clear();

            foreach (Note note in raspisanie.zametkitoday)
            {
                ZAMETKI.Items.Add(note.nazvanie);
            }
            NAZVANIE.Text = "";
            OPISANIE.Text = "";
        }




        private void ChangeSelect(object sender, SelectionChangedEventArgs e)
        {
            if (ZAMETKI.SelectedIndex != -1)
            {
                raspisanie.selectedTaskId = ZAMETKI.SelectedIndex;
                Note selectedNote = raspisanie.zametkitoday[raspisanie.selectedTaskId];
                NAZVANIE.Text = selectedNote.nazvanie;
                OPISANIE.Text = selectedNote.description;
            }
        }
   
        private void knopkaudaleniya(object sender, RoutedEventArgs e)
        {
            raspisanie.udalenie(todayId: raspisanie.selectedTaskId);
            izmspiskazametok();
        }
    }
}
