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
    class MapaViewModel:INotifyPropertyChanged
    {
        public ICommand Polynesia { get; set; }
        public ICommand China { get; set; }
        public ICommand Mexico { get; set; }
        public ICommand Mediterrania { get; set; }
        public ICommand FarWest { get; set; }

        public void polynesia(object parameter)
        {
            View.MapaPojedinacniView mpv = new View.MapaPojedinacniView();
            Viewmodels.MapaPojedinacnoViewModel mpvm = new Viewmodels.MapaPojedinacnoViewModel();
            DAL.DataBaseAtrakcije db = new DAL.DataBaseAtrakcije("amar");
            mpvm.Atrakcije = db.dajOdDo(1, 3);
            mpv.DataContext = mpvm;
            mpv.Show();
        }

        public void china(object parameter)
        {
            View.MapaPojedinacniView mpv = new View.MapaPojedinacniView();
            Viewmodels.MapaPojedinacnoViewModel mpvm = new Viewmodels.MapaPojedinacnoViewModel();
            DAL.DataBaseAtrakcije db = new DAL.DataBaseAtrakcije("amar");
            mpvm.Atrakcije = db.dajOdDo(4, 6);
            mpv.DataContext = mpvm;
            mpv.Show();
        }

        public void mediterrania(object parameter)
        {
            View.MapaPojedinacniView mpv = new View.MapaPojedinacniView();
            Viewmodels.MapaPojedinacnoViewModel mpvm = new Viewmodels.MapaPojedinacnoViewModel();
            DAL.DataBaseAtrakcije db = new DAL.DataBaseAtrakcije("amar");
            mpvm.Atrakcije = db.dajOdDo(7, 9);
            mpv.DataContext = mpvm;
            mpv.Show();
        }

        public void mexico(object parameter)
        {
            View.MapaPojedinacniView mpv = new View.MapaPojedinacniView();
            Viewmodels.MapaPojedinacnoViewModel mpvm = new Viewmodels.MapaPojedinacnoViewModel();
            DAL.DataBaseAtrakcije db = new DAL.DataBaseAtrakcije("amar");
            mpvm.Atrakcije = db.dajOdDo(10, 12);
            mpv.DataContext = mpvm;
            mpv.Show();
        }

        public void farwest(object parameter)
        {
            View.MapaPojedinacniView mpv = new View.MapaPojedinacniView();
            Viewmodels.MapaPojedinacnoViewModel mpvm = new Viewmodels.MapaPojedinacnoViewModel();
            DAL.DataBaseAtrakcije db = new DAL.DataBaseAtrakcije("amar");
            mpvm.Atrakcije = db.dajOdDo(13, 14);
            mpv.DataContext = mpvm;
            mpv.Show();
        }

        public MapaViewModel()
        {
            Polynesia = new RelayCommand(polynesia);
            Mediterrania = new RelayCommand(mediterrania);
            China = new RelayCommand(china);
            FarWest = new RelayCommand(farwest);
            Mexico = new RelayCommand(mexico);
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
