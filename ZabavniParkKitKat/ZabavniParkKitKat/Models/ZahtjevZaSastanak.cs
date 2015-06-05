using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class ZahtjevZaSastanak
    {
        private int ID { get; set; }
        private int prethodniID { get; set; }    //postaviti pocetnu vrijednost na 0
        private string status { get; set; }
        private DateTime datum { get; set; }
        private int kompanija { get; set; }
        private string nazivProizvoda { get; set; }
        private string obrazlozenje { get; set; }
    }
}
