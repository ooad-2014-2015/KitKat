using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Klase;
using System.Windows;
using System.Collections.ObjectModel;
using System.Threading;
using System.IO.Ports;

namespace ZabavniParkKitKat.Viewmodels
{
    class MainWindowViewModel:INotifyPropertyChanged
    {
        public ICommand Registracija { get; set; }
        public ICommand LogIn { get; set; }

        

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        public void login(object parametar)
        {
            DAL.DataBaseKompanije db1 = new DAL.DataBaseKompanije("amar");
            Kompanija kk= db1.dajPoUsernameU(Username);
            if (kk != null)
            {
                if (Password == kk.Password)
                {
                    View.KompanijaLogedIn kli = new View.KompanijaLogedIn();
                    Viewmodels.KompanijaLogedInViewModel klivm = new KompanijaLogedInViewModel(kk);
                    kli.DataContext = klivm;
                    kli.Show();
                }
                else MessageBox.Show("Pogresna sifra!");
                return;
            }


            DAL.DataBaseKupciKarte db2 = new DAL.DataBaseKupciKarte("amar");
            Models.KupacKarte kkupac = db2.dajPoUsernameU(Username);
            if (kkupac != null)
            {
                if (Password == kkupac.Password)
                {
                    // Login za korisnika KorisnikLogedInView i KorisnikLogedInViewModel
                    View.StavkaKupovineView st = new View.StavkaKupovineView();
                    Viewmodels.KupacKarteLogedInViewModel kp = new KupacKarteLogedInViewModel(kkupac);
                    st.DataContext = kp;
                    st.Show();
                }
                else MessageBox.Show("Pogresna sifra!");
                return;
            }

            MessageBox.Show("Korisnik ne postoji!");
        }

        public void registracija(object parameter)
        {
            View.RegistracijaView rv= new View.RegistracijaView();
            RegistracijaViewModel rvm = new RegistracijaViewModel();
            rv.DataContext = rvm;
            rv.Show();
        }

        public MainWindowViewModel()
        {
            LogIn = new RelayCommand(login);
            Registracija = new RelayCommand(registracija);
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
