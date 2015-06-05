using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MobilnaAplikacija
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
            tekst.Text = "Zabavni park je otvoren 1995.godine, a izgradila ga je cuvena filmska kompanija Universal Studios" + ". To se moze vidjeti i po velikoj statui posvecenoj Miki Mausu, kao" +
"i po Souvenir shopu koji se nalazi unutar parka." +
"Za detaljan obilazak ovog parka potrebno je nekoliko dana!" +
"Park je podijeljen uu 5 tematskih cjelina, tj. 5 dijelova svijeta:" +
"Mediteran, Polinezija, Kina, Meksiko i Divlji Zapad. " +
"Svaki od ovih delova je prica za sebe i svaki je uradjen sa dosta detalja sa namjerom da" +
"posjetioce na veoma uverljiv nacin vodi kroz neke daleke zemlje i predjele." +
"U ovom parku cete pronaci najbrze i najstrasnije roller coastere na svijetu," +
"ali se usput mozete osvjeziti i rashladiti na nekoj od nasih mnogobrojnih vodenih atrakcija." +
"Kada je rijec o sigurnosti i nesrecama u ovom zabavnom parku, do sada nije zabiljezen nijedan takav slucaj." +
"Ovaj zabavni park moze se pohvaliti visokom stopom sigurnosti i pouzdanosti svojih atrakcija," +
"tako da je veca vjerovatnoca da ce vam se desiti nesto na putu do parka, nego na nekoj od zabavnih atrakcija parka." +
"Osim sto je ovdje zavidno visoka stopa sigurnosti, isti epitet se moze dodijeliti i stopi adrenalina i zabave" +
"koju ovaj park pruza! Posjetite nas i dozivite cari ovog parka koje je prosto nemoguce opisati rijecima!";
        }

        private void naklik(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}