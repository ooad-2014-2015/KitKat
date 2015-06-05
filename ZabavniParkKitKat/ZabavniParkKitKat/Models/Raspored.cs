using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Raspored
    {
        private List<ZahtjevZaSastanak> zahtjevi { get; set; }

        public Raspored() { }
       // public Raspored(List<ZahtjevZaSastanak> zahtjevi, List<Reklama> reklame) { this.zahtjevi = zahtjevi; this.reklame = reklame; }
        public void pregledZahtjeva() { }
        public void pregledReklama() { }

        /* metode pregledZahtjeva i pregledReklama
         * 
         * public List<ZahtjeviZaSastanak> pregledZahtjeva() { return zahtjevi; }
         * public List<Reklama> pregledReklama() { return reklame; }
         * 
         * */

        //public void dodajReklamu(Reklama reklama) { this.reklame.Add(reklama); }
        public void dodajZahtjev(ZahtjevZaSastanak zahtjev) { this.zahtjevi.Add(zahtjev); }
        public void izmjeniStatus(string status) { }
    }
}
