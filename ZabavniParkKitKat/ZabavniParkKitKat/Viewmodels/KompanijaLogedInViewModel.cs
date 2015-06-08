using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klase;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ZabavniParkKitKat.Viewmodels
{
    class KompanijaLogedInViewModel:INotifyPropertyChanged
    {
        public ICommand SaljiZahtjev { get; set; }


        private string nazivProizvoda;

        public string NazivProizvoda
        {
            get { return nazivProizvoda; }
            set { nazivProizvoda = value; OnPropertyChanged("NazivProizvoda"); }
        }

        private string obrazlozenje;

        public string Obrazlozenje
        {
            get { return obrazlozenje; }
            set { obrazlozenje = value; OnPropertyChanged("Obrazlozenje"); }
        }
        private Kompanija kompanijaLogovana;

        public Kompanija KompanijaLogovana
        {
            get { return kompanijaLogovana; }
            set { kompanijaLogovana = value; OnPropertyChanged("KompanijaLogovana"); }
        }

        private DateTime datumSastanka;

        public DateTime DatumSastanka
        {
            get { return datumSastanka; }
            set { datumSastanka = value; OnPropertyChanged("DatumSastanka"); }
        }
        ObservableCollection<ZahtjevZaSastanak> sastanciKompanije;

        public ObservableCollection<ZahtjevZaSastanak> SastanciKompanije
        {
            get { return sastanciKompanije; }
            set { sastanciKompanije = value; OnPropertyChanged("SastanciKompanije"); }
        }

        public void zahtjevaj(object parameter)
        {
            int id = new DAL.DataBaseZahtjevi("amar").zadnjiId() + 1;
            ZahtjevZaSastanak zs = new ZahtjevZaSastanak(id, NazivProizvoda, Obrazlozenje, "Na cekanju", DatumSastanka);
            SastanciKompanije.Add(zs);
            new DAL.DataBaseZahtjevi("amar").dodaj(zs,KompanijaLogovana.Id);
        }

        public KompanijaLogedInViewModel(Kompanija kompanija)
        {
            datumSastanka = DateTime.Now;
            kompanijaLogovana = kompanija;
            sastanciKompanije = new DAL.DataBaseZahtjevi("amar").dajPoIduFirme(KompanijaLogovana.Id);
            SaljiZahtjev = new RelayCommand(zahtjevaj);

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
