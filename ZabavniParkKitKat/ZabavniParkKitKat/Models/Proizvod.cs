using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace Klase
{

    public class Proizvod : INotifyPropertyChanged
    {
        private int Id;

        public int ID
        {
            get { return Id; }
            set { Id = value; OnPropertyChanged("ID"); }
        }
        private int cijena;

        public int Cijena
        {
            get { return cijena; }
            set { cijena = value; OnPropertyChanged("Cijena"); }
        }

        private string tip;

        public string Tip
        {
            get { return tip; }
            set { tip = value; OnPropertyChanged("Tip"); }
        }

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }

        private BitmapImage slika;

        public BitmapImage Slika
        {
            get { return slika; }
            set { slika = value; OnPropertyChanged("Slika"); }
        }


        public Proizvod(int ID, int cijena, string tip, string ime, BitmapImage slika)
        {
            this.ID = ID;
            this.Cijena = cijena;
            this.Tip = tip;
            this.Ime = ime;
            this.Slika = slika;
        }
        public override string ToString()
        {
            return Ime;
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

