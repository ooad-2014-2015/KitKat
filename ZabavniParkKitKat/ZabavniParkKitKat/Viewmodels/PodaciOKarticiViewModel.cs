
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
            
                if (Kartica.IsValid) MessageBox.Show("Mozete preuzeti Vasu narudzbu!"+"Redni broj Vase narudzbe:"+(Kartica.Id_kartice%10).ToString());
                else MessageBox.Show("Validacija neuspjesna");
            
          

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
