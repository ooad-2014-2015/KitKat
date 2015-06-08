using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Klase
{
    public class Atrakcija:INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        private string tipAtrakcije;

        public string TipAtrakcije
        {
            get { return tipAtrakcije; }
            set { tipAtrakcije = value; OnPropertyChanged("TipAtrakcije"); }
        }

        private string opisAtrakcije;

        public string OpisAtrakcije
        {
            get { return opisAtrakcije; }
            set { opisAtrakcije = value; OnPropertyChanged("OpisAtrakcije"); }
        }

        private int ocjena;

        public int Ocjena
        {
            get { return ocjena; }
            set { ocjena = value; OnPropertyChanged("Ocjena"); }
        }

        private int kapacitet;

        public int Kapacitet
        {
            get { return kapacitet; }
            set { kapacitet = value; OnPropertyChanged("Kapacitet"); }
        }

        private BitmapImage slika;

        public BitmapImage Slika
        {
            get { return slika; }
            set { slika = value; OnPropertyChanged("Slika"); }
        }


        public Atrakcija() { }
        public Atrakcija(int id, string naziv, string tipAtrakcije, string opisAtrakcije, int ocjena, int kapacitet, BitmapImage slika)
        {
            this.id = id;
            this.naziv = naziv;
            this.tipAtrakcije = tipAtrakcije;
            this.opisAtrakcije = opisAtrakcije;
            this.ocjena = ocjena;
            this.kapacitet = kapacitet;
            this.slika = slika;
        }

        public override string ToString()
        {
            return naziv;
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
