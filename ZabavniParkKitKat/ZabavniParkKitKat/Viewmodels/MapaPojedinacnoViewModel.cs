using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Klase;
using System.Collections.ObjectModel;


namespace ZabavniParkKitKat.Viewmodels
{
    public class MapaPojedinacnoViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Atrakcija> atrakcije;

        public ObservableCollection<Atrakcija> Atrakcije
        {
            get { return atrakcije; }
            set { atrakcije = value; OnPropertyChanged("Atrakcije"); }
        }

        public ICommand Pritisak { get; set; }

        private Atrakcija odabranaAtrakcija;

        public Atrakcija OdabranaAtrakcija
        {
            get { return odabranaAtrakcija; }
            set { odabranaAtrakcija = value; OnPropertyChanged("OdabranaAtrakcija"); }
        }
        
        public MapaPojedinacnoViewModel() 
        {
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
