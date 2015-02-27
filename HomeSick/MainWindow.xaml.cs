using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeSick.Repository;
using HomeSick.Model;

namespace HomeSick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RemedyRepository repo = new RemedyRepository();
        public string RemedyTitleText { get; set; }
        public string RemedyNoteText { get; set; }
        public string RemedyTreatmentforText { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            RemedyList.DataContext = repo.Context().Remedies.Local;
        }

        private void AddTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RemedyTitleText = AddTitle.Text;
        }

        private void AddNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RemedyNoteText = AddNote.Text;
        }

        private void AddTreatmentFor_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RemedyTreatmentforText = AddTreatmentFor.Text;
        }

        private void AddSubmit_Click(object sender, RoutedEventArgs e)
        {
            repo.Add(new RemedyItem(RemedyTitleText, RemedyNoteText, RemedyTreatmentforText));
            AddTitle.Clear();
            AddNote.Clear();
            AddTreatmentFor.Clear();
        }



    }
}
