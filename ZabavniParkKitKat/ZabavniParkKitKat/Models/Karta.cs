using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{

    public enum period { Jednodnevna, Dvodnevna, Trodnevna };
    public class Karta: INotifyPropertyChanged
    {
        float cijena;
        string tip;
        string period;

        public string Period
        {
            get { return period; }
            set { period = value; OnPropertyChanged("Period"); }
        }

        public string Tip
        {
            get { return tip; }
            set { tip = value; if (tip == "TipA")cijena = 12; else if (tip == "Tip B")cijena = 9; else cijena = 0; OnPropertyChanged("Tip"); }
        }

        public float Cijena
        {
            get { return cijena; }
            set { cijena = value; OnPropertyChanged("Cijena"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
