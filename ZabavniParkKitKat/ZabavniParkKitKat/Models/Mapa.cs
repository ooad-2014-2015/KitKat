using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Mapa
    {
        private List<Atrakcija> listaAtrakcija { get; set; }

        public Mapa() { }
        public Mapa(List<Atrakcija> listaAtrakcija) { this.listaAtrakcija = listaAtrakcija; }
        public void dodajAtrakciju(Atrakcija atrakcija) { listaAtrakcija.Add(atrakcija); }
        public void obrisiAtrakciju(Atrakcija atrakcija) { listaAtrakcija.Remove(atrakcija); }
        public void prikaziAtrakcije() { } // isti problem kao i kod mape pa tako i isto rjesenje :)
        // public List<Atrakcija> prikaziAtrakcije() { return listaAtrakcija; }
    }
}
