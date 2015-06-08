using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klase;

namespace ZabavniParkKitKat.DAL
{
    interface IDataBase<O>
    {
        //Vrati sve iz tabele
        ObservableCollection<O> dajSve();

        //Daj objekat po ID
        O dajPoID(int id);

        //Dodaj jedan objekat, vraca true ako je uspjesno dodao
        bool dodaj(Object objekat);

        //Obrisi
        bool obrisi(O objekat);

        //Provjeri da li postoji objekat
        bool daLiPostoji(O objekat);

        

    }
}
