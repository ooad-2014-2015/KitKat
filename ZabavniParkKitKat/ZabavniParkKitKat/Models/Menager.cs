using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Menager
    {
        private int ID { get; set; }
        private int prethodniID { get; set; }   //ttreba pocetnu vrijednost staviti na 0
        private string ime { get; set; }
        private string prezime { get; set; }
        private string username { get; set; }
        private string password { get; set; }
        private string email { get; set; }
        private string brojTelefona { get; set; }

        public Menager() { }
        public Menager(string username) { this.username = username; }
        public string dajMail() { return email; }
        public string dajIme() { return ime; }
        public string dajPrezime() { return prezime; }
        public string dajBrojTelefona() { return brojTelefona; }
        public int dajID() { return ID; }
        public void dodjeliID() { ID = prethodniID + 1; }       //valjda ovako dodjeljujemo ID
        public void izmjeniIme(string ime) { this.ime = ime; }
        public void izmjeniPrezime(string prezime) { this.prezime = prezime; }
        public void izmjeniMail(string email) { this.email = email; }
        public void izmjeniBrojTelefona(string brojTelefona) { this.brojTelefona = brojTelefona; }
    }
}
