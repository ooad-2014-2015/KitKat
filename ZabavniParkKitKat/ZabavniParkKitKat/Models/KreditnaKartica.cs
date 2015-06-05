using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZabavniParkKitKat.Models
{
    public class KreditnaKartica : INotifyPropertyChanged, IDataErrorInfo
    {
        private int id_kartice;
        public int Id_kartice
        {
            get { return id_kartice; }
            set { id_kartice = value; OnPropertyChanged("Id_kartice"); }
        }
        private DateTime datum_isteka;
        public DateTime Datum_isteka
        {
            get { return datum_isteka; }
            set { datum_isteka = value; OnPropertyChanged("Datum_isteka"); }
        }
        private int ccv;
        public int Ccv
        {
            get { return ccv; }
            set { ccv = value; OnPropertyChanged("Ccv"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in validateProperties)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static readonly string[] validateProperties = { "Id_kartice", "Datum_isteka", "Ccv" };

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }

        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Id_kartice":
                    error = validirajBroj();
                    break;
                case "Datum_isteka":
                    error = validirajDatum();
                    break;
                case "Ccv":
                    error = validrajCcv();
                    break;
            }
            return error;
        }
        private string validirajBroj()
        {
            string BrojKreditneKartice = Id_kartice.ToString();
            if (String.IsNullOrWhiteSpace(BrojKreditneKartice) || Id_kartice == 0)
            {
                return "Id kreditne kartice mora bit unesen!";
            }
            //510510510510510 mastercard testna kartica ispravna
            if (!BrojKreditneKartice.LuhnCheck() || BrojKreditneKartice.Length > 19 || BrojKreditneKartice.Length < 1)
            {
                return "Broj kreditne kartice ne postoji!";
            }
            return null;
        }
        private string validrajCcv()
        {
            if (Ccv < 1000 || Ccv > 9999) return "CCV mora bit cetverocifren broj!";
            return null;
        }
        private string validirajDatum()
        {
            if (Datum_isteka <= DateTime.Now)
            {
                return "Unesite datum u budcnosti!";
            }
            return null;
        }


        public KreditnaKartica(int id_karticee, int _ccv, DateTime datum_istekaa)
        {
            this.Id_kartice = id_karticee;
            this.Ccv = _ccv;
            this.Datum_isteka = datum_istekaa;
        }
        public KreditnaKartica()
        {
            Datum_isteka = DateTime.UtcNow;
        }


    }
}
