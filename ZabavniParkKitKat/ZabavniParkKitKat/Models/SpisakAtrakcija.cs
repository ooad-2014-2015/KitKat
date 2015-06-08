using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class SpisakAtrakcija
    {
        private List<Atrakcija> listaAtrakcija { get; set; }

        public SpisakAtrakcija() { }
        public SpisakAtrakcija(List<Atrakcija> listaAtrakcija) { this.listaAtrakcija = listaAtrakcija; }
        public void izlistajAtrakcije() {  }    // kako da ih izlista? jedino sta mi pada na pamet je ovo ispod
        // public List<Atrakcija> izlistajAtrakcije() { return listaAtrakcija; }
        
        public void dodajAtrakciju(Atrakcija atrakcija) { listaAtrakcija.Add(atrakcija); }
    }
}
