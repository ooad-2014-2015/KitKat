using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ZabavniParkKitKat.View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : Window
    {
        public HelpView()
        {
            InitializeComponent();
            tbl.Text="Na glavnom formi mozete izabrati sljedece meni opcije:\n"+
"Mapa, Atrakcije, Shop, O nama i Help.n"+
"Klikom na opciju Mapa mozete da pogledate pregled parka, odnosno klikom\n"+
"na odgovarajucu oblast na slici mape otvara se nova forma na kojoj se nalaze\n"+
"atrakcije koje su smjeste u toj oblasti parka. Mozete pregledati slike atrakcija, kao i opise i ocjene.\n"+
"Ukoliko izaberete opciju Atrakcije, omogucen Vam je pregled svih atrakcija parka.\n"+
"Klikom na opciju Shop mozete da kreirate Vasu narudzbu u souvenir shopu. Klikom na dugme\n"+
"Dodaj stavke otvara vam se forma na kojoj mozete da birate artikle koji su tipa suveniri ili tipa fotogafije.\n"+
"Za svaki artikal je omogucen prikaz slike artikla i unos kolicine. Nakon sto se doda u korpu, naruceni artikal se pojavljuje na formi Narudzba.Selektovanjem stavke narudzbe i klikom na dugme Obrisi stavku korisnik brise stavku iz korpe, \n"+
"dok klikom na dugme Posalji narudzbu daje znak da zeli da izvrsi placanje rezervisanih artikala.\n"+
"Nakon toga otvara se forma za unos podataka o kartici, vrsi se validacija istih, te nakon klika na dugme Potvrdi korisnik obavjestava o ishodu validacije.\n"+
"Klikom na meni opciju O nama mozete procitati kraci opis zabavnog parka, a klikom na dugme Help upute o koristenju aplikacije.\n"+
"Registracija korisnika se vrsi tako sto se klikne na dugme Registracija i na formi za registraciju se unose odgovarajuci podaci. Zatim se korisnik registruje u bazu korisnika ako prije nije bio registrovan.\n"+
"Ukoliko korisnik vec ima korisnicicki racun, unosom username-a i passworda na glavnom formi, te klikom na dugme LogIn, korisnik se prijavljuje na sistem.\n"+
"U zavisnosti od tipa korisnika, nakon logovanja otvara se odgovarajuca forma.\n"+
"Npr. za online kupca se otvara forma za kupovinu karata, gdje korisnik bira tip karte, period karte i rezervaciju parkinga.\n"+
"Za kompaniju se otvara forma za slanje zahtjeva za sastanak sa menadzerom parka. Unosom podataka u pomenutu formu, te klikom na dugme Posalji, zahtjev se spasava u bazu, a menadzer nakon logovanja moze da vrsi pregled istih.\n\n\n"+
"Nalazenje dijelova koji ulaze u bodovanje:\n"+
"-baza podataka se koristi pomocu DAL sloja za pristup bazi, koji se moze naci u vidu foldera u \n"+
" solution exploreru, baza je napravljena u MS SQL Server Express 2014 i lokalnog je tipa\n"+
"-vanjski uredjaj koji se koristi u nasem projektu jeste arduino, koji sluzi kao eksterni uredjaj\n"+
" za 'brzo' logovanje menadzera, nalazi se u MainWindow.xaml.cs ( o ovome ce biti rijeci kasnije ) \n"+
"-thread se koristi na istom mjestu gdje i vanjski uredjaj , tj to su dvije stavke koje su zajedno izvedene\n"+
"-korisnicki interface je pred vama \n"+
"-fukcionalnosti su u skladu sa 90% opisanog pod specifikacijom ( i o ovome ce biti kasnije rijeci) \n"+
"-help trenutno citate\n\n"+
"Dijelovi koji nose bodove a nisu prilozeni u ovom projektu:\n"+
"-na nasem gitu se nalazi igrica, wp8 aplikacija, dnevnici rada i kod za arduino\n\n"+
"Dvije stvari koje su ranije navedene su kod za vanjski uredjaj i kod za thread koji se nalaze u MainWindow.xaml.cs\n"+
"fajlu. Oni konceptualno krse mvvm pattern, ali to nije uradjeno bez razloga. Ove dvije stavke kombinuju stvari\n"+
"koje jako lose funkcionisu sa mvvm patternom i wpf-om. U wpf-u nije dozvoljeno da non-UI thread poziva UI metode\n"+
"( sto se kod nas desava, nakon ocitanja signala sa arduina, njegov thread pokusava napraviti novi prozor), tako da ovo \n"+
"predstavlja blago krsenje mvvm principa, ali sa svrhom izbjegavanja 'prljavih trikova' koji bi bili potrebni \n"+
"da se ovaj pristup prilagodi mvvm patternu.\n\n"+
"Jos jedna stvar koja se protivi mvvm-u jeste da neka dugmad ( neznatan broj, najvise 4) otvaraju prozore na \n"+
"button click event. Ovo se protivi Cistoj mvvm filozofiji, ali na konceptualnom nivou ne predstavlja nikakvu \n"+
"gresku.\n\n"+
"Treba naglasiti da je asistent bio u pravu, kada nam je rekao da nam je projekat previse opsiran. Posto je to tako\n"+ 
"nismo bili u stanju ispuniti sva svoja 'obecanja' data u specifikaciji, ali su zadovoljena uz najmanja moguca odstupanja.\n\n\n\n"+
"Zavrsne rijeci: \n"+
"Iako ovo nije bio jednostavan zadatak, mozemo reci da smo zadovoljni postignutim rezultatom rada i znanjem koje\n"+
"smo stekli prilikom istog. Ovo je bilo jedno iskustvo koje ce nas sigurno dobro pripremiti na buduce izazove u \n"+
"'pravom zivotu'. Nadamo se da ste vi zadovoljni koliko smo i mi.\n"+"Tim KitKat";
        }
    }
}
