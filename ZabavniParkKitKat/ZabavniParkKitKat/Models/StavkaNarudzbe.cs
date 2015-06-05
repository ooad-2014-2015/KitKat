using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Klase
{
   
    public class StavkaNarudzbe:INotifyPropertyChanged
    {

        private int kolicina;

        public int Kolicina
        {
            get { return kolicina; }
            set { if (value < 0) value = 0; kolicina = value; OnPropertyChanged("Kolicina"); }
        }
        private float ukupnaCijena;

        public float UkupnaCijena
        {
            get { return ukupnaCijena; }
            set { ukupnaCijena = value; OnPropertyChanged("UkupnaCijena"); }
        }    
        private Proizvod artikal;

        public Proizvod Artikal
        {
            get { return artikal; }
            set { artikal = value; OnPropertyChanged("Artikal"); }
        }

        private string imeArtikla;

        public string ImeArtikla
        {
            get { return imeArtikla; }
            set { imeArtikla = value; OnPropertyChanged("ImeArtikla"); }
        }
        public StavkaNarudzbe()
        {

        }
        public StavkaNarudzbe(int kolicina, Proizvod p) { this.Kolicina = kolicina; this.Artikal = p; this.UkupnaCijena = Kolicina * Artikal.Cijena; }

        public override string ToString()
        {
            return Artikal.Tip+" "+Artikal.Ime + " x " + Kolicina.ToString()+ "   "+Convert.ToString (Artikal.Cijena*Kolicina)+"KM";
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
