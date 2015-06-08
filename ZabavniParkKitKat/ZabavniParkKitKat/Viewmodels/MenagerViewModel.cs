using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klase;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ZabavniParkKitKat.Viewmodels
{
    class MenagerViewModel:INotifyPropertyChanged
    {
        public ICommand Prihvati { get; set; }
        public ICommand Odbij { get; set; }

        private ObservableCollection<ZahtjevZaSastanak> zahtjevi;

        public ObservableCollection<ZahtjevZaSastanak> Zahtjevi
        {
            get { return zahtjevi; }
            set { zahtjevi = value; OnPropertyChanged("Zahtjevi"); }
        }

        private ZahtjevZaSastanak odabrani;

        public ZahtjevZaSastanak Odabrani
        {
            get { return odabrani; }
            set { odabrani = value; OnPropertyChanged("Odabrani"); }
        }

        public MenagerViewModel()
        {
            zahtjevi = new DAL.DataBaseZahtjevi("amar").dajSveNaCekanju();
            odabrani = new ZahtjevZaSastanak();
            Prihvati = new RelayCommand(prihvati);
            Odbij = new RelayCommand(odbij);
        }

        public void prihvati(object parameter)
        {
            if (Odabrani != null)
            {
                DAL.DataBaseZahtjevi db = new DAL.DataBaseZahtjevi("amar");
                db.prihvati(Odabrani.Id);
                Zahtjevi = db.dajSveNaCekanju();
            }
        }
        public void odbij(object parameter)
        {
            if (Odabrani != null)
            {
                DAL.DataBaseZahtjevi db = new DAL.DataBaseZahtjevi("amar");
                db.odbij(Odabrani.Id);
                Zahtjevi = db.dajSveNaCekanju();
            }
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
