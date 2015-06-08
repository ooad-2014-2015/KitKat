using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Kompanija:INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        private string naziv;

        public string Naziv
        {
              get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        } 
                private string username;

        public string Username
        {
          get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }
                private string email;

        public string Email
        {
          get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }
        private string password;

        public string Password
        {
          get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        public Kompanija()
        {
        }

        public Kompanija(int id,string naziv, string email, string username, string password)
        {
            this.id = id;
            this.naziv = naziv;
            this.email = email;
            this.username = username;
            this.password = password;
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
