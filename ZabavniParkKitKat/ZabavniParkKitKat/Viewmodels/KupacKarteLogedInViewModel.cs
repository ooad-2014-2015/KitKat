using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ZabavniParkKitKat.Viewmodels
{
    class KupacKarteLogedInViewModel:INotifyPropertyChanged
    {
        private Klase.Karta karta;

        public Klase.Karta Karta
        {
            get { return karta; }
            set { karta = value; OnPropertyChanged("Karta"); }
        }

        private ObservableCollection<String> listaTip;

        public ObservableCollection<String> ListaTip
        {
            get { return listaTip; }
            set { listaTip = value; OnPropertyChanged("ListaTip"); }
        }

        private ObservableCollection<String> listaPeriod;

        public ObservableCollection<String> ListaPeriod
        {
            get { return listaPeriod; }
            set { listaPeriod = value; OnPropertyChanged("ListaPeriod"); }
        }

        private ObservableCollection<String> listaParking;

        public ObservableCollection<String> ListaParking
        {
            get { return listaParking; }
            set { listaParking = value; OnPropertyChanged("ListaParking"); }
        }
 
        private Models.KupacKarte kupac;

        public Models.KupacKarte Kupac
        {
            get { return kupac; }
            set { kupac = value; OnPropertyChanged("Kupac"); }
        }

        public ICommand pritisak { get; set; }
        public KupacKarteLogedInViewModel(Models.KupacKarte k)
        {
            Kupac = k;
            pritisak = new RelayCommand(kupovinaKarte);
            Karta = new Klase.Karta();
           
            listaTip = new ObservableCollection<String>();
            listaTip.Add("Tip A");
            listaTip.Add("Tip B");
            listaPeriod = new ObservableCollection<String>();
            listaPeriod.Add("Jednodnevna");
            listaPeriod.Add("Dvodnevna");
            listaPeriod.Add("Trodnevna");
            listaParking = new ObservableCollection<String>();
            listaParking.Add("Da");
            listaParking.Add("Ne");
            

            
        }
        public KupacKarteLogedInViewModel()
        {
            pritisak = new RelayCommand(kupovinaKarte);
        }
        public void kupovinaKarte(object parameter)
        {
            
             View.PodaciOKartici pk = new View.PodaciOKartici();
             Viewmodels.PodaciOKarticiViewModel pkvm = new PodaciOKarticiViewModel();
           // MessageBox.Show(Karta.Tip+" " +Karta.Parking+" "+Karta.Period+Karta.Kolicina.ToString());
         
   
             pk.DataContext = pkvm;
            
             //if (ListaStavki.Count != 0) pk.Show();
             if (Karta.Tip != null && Karta.Parking != null && Karta.Period != null)
             {
                 MessageBox.Show("Uspjesno ste izabrali stavku kupovine! Za placanje stavke kliknite na OK.");
                 pk.Show();
             }
             else MessageBox.Show("Niste izabrali informaciju o karti");
           
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
