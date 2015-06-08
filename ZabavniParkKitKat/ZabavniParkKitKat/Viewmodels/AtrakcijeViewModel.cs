using Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabavniParkKitKat.Viewmodels
{
    class AtrakcijeViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Atrakcija> atrakcije;

        public ObservableCollection<Atrakcija> Atrakcije
        {
            get { return atrakcije; }
            set { atrakcije = value; OnPropertyChanged("Atrakcije"); }
        }

        private Atrakcija odabranaAtrakcija;

        public Atrakcija OdabranaAtrakcija
        {
            get { return odabranaAtrakcija; }
            set { odabranaAtrakcija = value; OnPropertyChanged("OdabranaAtrakcija"); }
        }

        public AtrakcijeViewModel()
        {
            DAL.DataBaseAtrakcije db = new DAL.DataBaseAtrakcije("amar");
            Atrakcije = db.dajSve();
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
