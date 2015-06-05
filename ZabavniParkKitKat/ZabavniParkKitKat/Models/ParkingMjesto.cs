using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class ParkingMjesto
    {
        private int ID { get; set; }
        private string zona { get; set; }
        private DateTime datum { get; set; }
        private bool slobodno { get; set; }

        public ParkingMjesto() { }
        public ParkingMjesto(int ID, string zona) { this.ID = ID; this.zona = zona; slobodno = false;  } //slobodno = false po default-u
        public bool vratiStatus(DateTime datum) { if (datum == this.datum) return false; else return true; }//valjda ako je datum isti onda je parkingMjesto zauzeto no ovo mi nema smisla. 
                                                                                                            //Mislim da treba provjeravati i po ID-u parkingMjesta :S
        public string vratiZonu() { return zona; }
        public int vratiID() { return ID; }
    }
}
