
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Klase;

namespace ZabavniParkKitKat.Viewmodels
{
    class StavkaNarudzbeViewModel:INotifyPropertyChanged
    {
        
        private ObservableCollection<Klase.Proizvod> lista;

        public ObservableCollection<Klase.Proizvod> Lista
        {
            get { return lista; }
            set { lista = value; OnPropertyChanged("Lista"); }
        }

        private ObservableCollection<StavkaNarudzbe> stavke;

        public ObservableCollection<StavkaNarudzbe> Stavke
        {
            get { return stavke; }
            set { stavke = value; OnPropertyChanged("Stavke"); }
        }
        private int kolicina;

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged("Kolicina"); }
        }

        private Proizvod odabrani;

        public Proizvod Odabrani
        {
            get { return odabrani; }
            set { odabrani = value; OnPropertyChanged("Odabrani"); }
        }


        public void pritisak1(object parameter)
        {
            //MessageBox.Show("Radiiii");
            ZabavniParkKitKat.DAL.DataBaseArtikli baza = new DAL.DataBaseArtikli("Lejla");
            Lista = baza.dajFotografije();
        }

        public void pritisak2(object parameter)
        {
            ZabavniParkKitKat.DAL.DataBaseArtikli baza = new DAL.DataBaseArtikli("Lejla");
            Lista = baza.dajSuvenire();
           
        }
        public void pritisak3(object obj)
        {
            if(Kolicina>0)
            Stavke.Add(new StavkaNarudzbe(Kolicina, Odabrani));
        }

        public ICommand Fotografija { get; set; }
        public ICommand Suvenir { get; set; }
        public ICommand DodajUKorpu { get; set; }

        public StavkaNarudzbeViewModel(ObservableCollection<StavkaNarudzbe> s)
        {
            DodajUKorpu = new RelayCommand(pritisak3);
            Stavke = s;
            Fotografija=new RelayCommand(pritisak1);
            Suvenir = new RelayCommand(pritisak2);

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
