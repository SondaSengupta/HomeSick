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
        int getId;
        RemedyItem toDeletefromId;
        RemedyItem editSelection;
        string[] MultipleTreatments;

        public MainWindow()
        {
            InitializeComponent();
            RemedyList.DataContext = repo.Context().Remedies.Local;
            TreatmentComboBox.ItemsSource = repo.GetTreatments();
        }

        private void AddTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RemedyTitleText = AddTitle.Text.ToUpper();
        }

        private void AddNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RemedyNoteText = AddNote.Text;
        }

        
        private void AddTreatmentFor_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.RemedyTreatmentforText = " " + AddTreatmentFor.Text.ToUpper();
        }

        
        private void AddSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(RemedyTitleText) == true || string.IsNullOrEmpty(RemedyNoteText) == true || string.IsNullOrEmpty(RemedyTreatmentforText) == true)
            {
                MessageBox.Show("You must fill in all fields before submitting");
            }
            else
            {
                CheckAddforMultipleTreatments();
                InputClearAll();
                if (getId != 0)
                {
                    repo.Delete(toDeletefromId);
                }
                TreatmentComboBox.ItemsSource = repo.GetTreatments();
            }
        }

        private void InputClearAll()
        {
            AddTitle.Clear();
            AddNote.Clear();
            AddTreatmentFor.Clear();
            RemedyFields.Content = "Add a Remedy";
            EditButton.Visibility = Visibility.Collapsed;
        }

        private void CheckAddforMultipleTreatments()
        {
            if (RemedyTreatmentforText.Contains(","))
            {
                MultipleTreatments = RemedyTreatmentforText.Split(',');
                for (int i = 0; i < MultipleTreatments.Length; i++)
                {
                    repo.Add(new RemedyItem(RemedyTitleText, RemedyNoteText, MultipleTreatments[i]));
                }
            }
            else
            {
                repo.Add(new RemedyItem(RemedyTitleText, RemedyNoteText, RemedyTreatmentforText));
            }
        }

        object specifiedTreatment;
        private void selectedTreatment(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                specifiedTreatment = TreatmentComboBox.SelectedItem.ToString();
            }
            catch
            {   
            }
           RemedyList.DataContext = repo.GetByTreatmentFor(specifiedTreatment);
           InputClearAll();
          
        }

        private void ShowAllRemedies_Click(object sender, RoutedEventArgs e)
        {
            TreatmentComboBox.SelectedIndex = -1;
            RemedyList.DataContext = repo.Context().Remedies.Local;  
        }


        private void RemedyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try
            { 
              editSelection = RemedyList.SelectedItems[0] as RemedyItem;
              getId = editSelection.RemedyItemId;
              toDeletefromId = repo.GetById(getId) as RemedyItem;
            }
            catch
            {
            }
            AddNote.Text = editSelection.RemedyNote;
            AddNote.Text = editSelection.RemedyNote;
            AddTitle.Text = editSelection.RemedyTitle;
            AddTreatmentFor.Text = editSelection.RemedyTreatmentFor;
            EditButton.Visibility = Visibility.Visible;
            RemedyFields.Content = "Edit this Remedy";
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {  
            repo.Delete(toDeletefromId);
            InputClearAll();
            EditButton.Visibility = Visibility.Collapsed;
            TreatmentComboBox.ItemsSource = repo.GetTreatments();
        }

        private void ImagePath_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            ImagePathTextBox.Text = dlg.FileName;
            string ImagePathstring = dlg.FileName;
            Uri imageUri = new Uri(ImagePathstring);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            RemedyImage.Source = imageBitmap;
        }

        private void ImagePathTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
