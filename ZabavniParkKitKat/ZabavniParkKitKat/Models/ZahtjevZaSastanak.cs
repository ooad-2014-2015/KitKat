using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class ZahtjevZaSastanak:INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

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

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        private DateTime datumSastanka;

        public DateTime DatumSastanka
        {
            get { return datumSastanka; }
            set { datumSastanka = value; OnPropertyChanged("DatumSastanka"); }
        }
        public ZahtjevZaSastanak()
        {
               
        }
        public ZahtjevZaSastanak(int id,string nazivProizvoda,string obrazlozenje,string status,DateTime datumSastanka)
        {
            this.id = id;
            this.nazivProizvoda = nazivProizvoda;
            this.obrazlozenje = obrazlozenje;
            this.status = status;
            this.datumSastanka = datumSastanka;
        }
        public override string ToString()
        {
            return id.ToString() + "-" + nazivProizvoda + "-" + datumSastanka.ToShortDateString() + "-" + status;
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
