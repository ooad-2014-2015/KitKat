
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ZabavniParkKitKat.Viewmodels
{
    class PodaciOKarticiViewModel:INotifyPropertyChanged
    {
        private ZabavniParkKitKat.Models.KreditnaKartica kartica;

        public ZabavniParkKitKat.Models.KreditnaKartica Kartica
        {
            get { return kartica; }
            set { kartica = value; OnPropertyChanged("Kartica"); }
        }



        public ICommand Potvrdi { get; set; }

        public PodaciOKarticiViewModel()
        {
            Potvrdi = new RelayCommand(plati);
            Kartica = new Models.KreditnaKartica();
         
        }

        public void plati(object obj)
        {
            
           if (Kartica.Datum_isteka<=DateTime.Now || Kartica.Ccv<1000 ||Kartica.Ccv>9999) MessageBox.Show("Transakcija je neuspjesna!");
            else MessageBox.Show("Validacija uspjesna! Kupovina je uspjesno obavljena!");
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
