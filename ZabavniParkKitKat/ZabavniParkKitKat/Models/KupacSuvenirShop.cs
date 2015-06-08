using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class KupacSuvenirShop
    {
        private string brojKartice { get; set; }
        private DateTime istekKartice { get; set; }
        private int ID { get; set; }

        public KupacSuvenirShop() { }
        public KupacSuvenirShop(string brojKartice) { this.brojKartice = brojKartice; }
        public int dajID() { return ID; }
        public void postaviID(int ID) { this.ID = ID; }
        public string dajBrojKartice() { return brojKartice; }
        public DateTime dajIstekKartice() { return istekKartice; }
        public void postaviIstek(DateTime istekKartice) { this.istekKartice = istekKartice; }
    }
}
