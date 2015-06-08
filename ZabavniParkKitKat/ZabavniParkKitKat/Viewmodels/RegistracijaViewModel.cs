using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Klase;

namespace ZabavniParkKitKat.Viewmodels
{
    class RegistracijaViewModel: INotifyPropertyChanged
    {
        public ICommand RegistracijaKompanije { get; set; }
        public ICommand RegistracijaKupca { get; set; }

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }
        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }
        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; OnPropertyChanged("Adresa"); }
        }
        private string kompanijaUsername;

        public string KompanijaUsername
        {
            get { return kompanijaUsername; }
            set { kompanijaUsername = value; OnPropertyChanged("KompanijaUsername"); }
        }
        private string kompanijaPw;

        public string KompanijaPw
        {
            get { return kompanijaPw; }
            set { kompanijaPw = value; OnPropertyChanged("KompanijaPw"); }
        }
        private string korisnikUsername;

        public string KorisnikUsername
        {
            get { return korisnikUsername; }
            set { korisnikUsername = value; OnPropertyChanged("KorisnikUsername"); }
        }

        private string korisnikPw;

        public string KorisnikPw
        {
            get { return korisnikPw; }
            set { korisnikPw = value; OnPropertyChanged("KorisnikPw"); }
        }


        public void regkorisnik(object parameter)
        {
            if (ime != "" && prezime != "" && korisnikUsername != "" && korisnikPw != "" && adresa != "")
            {
                Models.KupacKarte kk = new DAL.DataBaseKupciKarte("amar").dajPoUsernameU(korisnikUsername);
                if (kk == null)
                {
                    DAL.DataBaseKupciKarte db=new DAL.DataBaseKupciKarte("amar");
                    int id = db.zadnjiId() + 1;
                    kk = new Models.KupacKarte(id,Ime,Prezime,Adresa,KorisnikUsername,KorisnikPw);
                    db.dodaj(kk);
                    
                }
            }
        }

        public void regkompanija(object parameter)
        {
            if (naziv != "" && email != "" && kompanijaUsername != "" && kompanijaPw != "")
            {
                Kompanija kk = new DAL.DataBaseKompanije("amar").dajPoUsernameU(kompanijaUsername);
                if (kk == null)
                {
                    DAL.DataBaseKompanije db = new DAL.DataBaseKompanije("amar");
                    int id = db.zadnjiId() + 1;
                    kk = new Kompanija(id, Naziv, Email, KompanijaUsername,KompanijaPw);
                    db.dodaj(kk);

                }
            }
        }
        public RegistracijaViewModel()
        {
            RegistracijaKupca = new RelayCommand(regkorisnik);
            RegistracijaKompanije = new RelayCommand(regkompanija);
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
