using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    class Parking
    {
        private int brojMjesta { get; set; }
        private List<ParkingMjesto> parkingMjesta { get; set; }

        public Parking() { }
        public Parking(int brojMjesta) { this.brojMjesta = brojMjesta; }
        public Parking(List<ParkingMjesto> parkingMjesta) { this.parkingMjesta = parkingMjesta; }
        public void rezervisiParking(ParkingMjesto parkingMjesto, DateTime datum) { if(!parkingMjesto.vratiStatus(datum)) this.parkingMjesta.Add(parkingMjesto); }
        public void osolobodiParking(ParkingMjesto parkingMjesto, DateTime datum) { if(parkingMjesto.vratiStatus(datum)) this.parkingMjesta.Remove(new ParkingMjesto(parkingMjesto.vratiID(), parkingMjesto.vratiZonu())); }
        public bool ocitajStatus(ParkingMjesto parkingMjesto, DateTime datum) { return this.parkingMjesta.Find(x => x.vratiID().Equals(parkingMjesto.vratiID())).vratiStatus(datum); }  //ovo bi trebalo proci :$ 
    }
}
