using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeSick.Model
{
    public class RemedyItem: INotifyPropertyChanged
    {
        public int RemedyItemId { get; set; }
        public string RemedyTitle { get; set; }
        public string RemedyNote { get; set; }
        public string RemedyTreatmentFor { get; set; }
        public string RemedyImagePath { get; set; }

        public RemedyItem()
        {

        }

        public RemedyItem(string RemedyTitle, string RemedyNote, string RemedyTreatmentFor, string RemedyImagePath = "cat.jpg")
        {
            this.RemedyTitle = RemedyTitle;
            this.RemedyNote = RemedyNote;
            this.RemedyTreatmentFor = RemedyTreatmentFor;
            this.RemedyImagePath = RemedyImagePath;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
