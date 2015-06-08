using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klase;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ZabavniParkKitKat.Viewmodels
{
    class NarudzbaViewModel:INotifyPropertyChanged
    {
       private StavkaNarudzbeViewModel stavkaNarudzbeVM;

        public StavkaNarudzbeViewModel StavkaNarudzbeVM
        {
            get { return stavkaNarudzbeVM; }
            set { stavkaNarudzbeVM = value; OnPropertyChanged("StavkaNarudzbeVM"); }
        }
        private StavkaNarudzbe sn;

        public StavkaNarudzbe Sn
        {
            get { return sn; }
            set { sn = value; OnPropertyChanged("Sn"); }
        }
        private StavkaNarudzbe odabranaStavkaNarudzbe;

        public StavkaNarudzbe OdabranaStavkaNarudzbe
        {
            get { return odabranaStavkaNarudzbe; }
            set { odabranaStavkaNarudzbe = value; OnPropertyChanged("OdabranaStavkaNarudzbe"); }
        }

        private ObservableCollection<StavkaNarudzbe> listaStavki;

        public ObservableCollection<StavkaNarudzbe> ListaStavki
        {
            get { return listaStavki; }
            set { listaStavki = value; OnPropertyChanged("ListaStavki"); }
        }
        public ICommand DodajStavku { get; set; }

        public ICommand DodajUKorpu { get; set; }
        public ICommand ObrisiStavku { get; set; }
        public ICommand PosaljiNarudzbu { get; set; }

        public NarudzbaViewModel()
        {
            //Sn = new StavkaNarudzbe();
            ListaStavki=new ObservableCollection<StavkaNarudzbe>();
            ListaStavki.Add(Sn);
            DodajStavku=new RelayCommand(kliknuto);
            DodajUKorpu = new RelayCommand(uKorpu);
            ObrisiStavku = new RelayCommand(obrisi);
            PosaljiNarudzbu = new RelayCommand(posalji);

        }

        public void obrisi(object obj)
        {
            ListaStavki.Remove(OdabranaStavkaNarudzbe);
          //  ListaStavki.RemoveAt(ListaStavki.IndexOf(OdabranaStavkaNarudzbe));
        }
         public void kliknuto(object parameter)
        {
            View.StavkaNarudzbeView s = new View.StavkaNarudzbeView();
            Viewmodels.StavkaNarudzbeViewModel snvm = new StavkaNarudzbeViewModel(ListaStavki);
            s.DataContext = snvm;
            /*Sn.Artikal = snvm.Odabrani;
            Sn.Kolicina = snvm.Kolicina;
            ListaStavki.Add();
            snvm.DodajUKorpu = this.DodajUKorpu;*/
           
            s.Show();
           //ne smije znati
        }

         public void posalji(object obj)
         {
             View.PodaciOKartici pk = new View.PodaciOKartici();
             Viewmodels.PodaciOKarticiViewModel pkvm = new PodaciOKarticiViewModel();
             pk.DataContext = pkvm;
             if(ListaStavki.Count!=0) pk.Show();
         }

         public void uKorpu(object parameter)
         {
             ListaStavki.Add(Sn);
         }

        public override string ToString()
        {
            return Sn.ImeArtikla;
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
