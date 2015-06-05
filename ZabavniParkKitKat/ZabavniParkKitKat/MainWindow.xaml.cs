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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Klase;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Klase;


namespace ZabavniParkKitKat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort arduinoBoard;
        public string username { get; set; }
        public MainWindow()
        {
            InitializeComponent();
          /*  arduinoBoard = new SerialPort("COM3");
            arduinoBoard.Open();*/
            /*string connectionStringKomentari = "Integrated Security=true;Initial Catalog=KitKat; " + "Data Source=PROBOOK450\\SQLEXPRESS";
            SqlConnection connKomentari = new SqlConnection(connectionStringKomentari);
            connKomentari.Open();*/
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*View.RegistracijaView r = new View.RegistracijaView();
            r.Show();*/
            MessageBox.Show(username);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            View.MapaView m = new View.MapaView();
            Viewmodels.MapaViewModel mvm = new Viewmodels.MapaViewModel();
            m.DataContext = mvm;
            m.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*arduinoBoard.Write("5");*/
            //new View.MapaPojedinacniView().Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            View.AtrakcijeView av = new View.AtrakcijeView();
            Viewmodels.AtrakcijeViewModel avm = new Viewmodels.AtrakcijeViewModel();
            av.DataContext = avm;
            av.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //DAL.DataBaseKompanije db = new DAL.DataBaseKompanije("amar");
            DAL.DataBaseKupciKarte db = new DAL.DataBaseKupciKarte("amar");
            Models.KupacKarte kk = new Models.KupacKarte(1, "Amar", "Panjeta", "Grb8a", "draCo", "tojeto");
            //Kompanija k = db.dajPoUsernameU("ooad");
            //Kompanija k = new Kompanija(2, "KitKat", "apanjeta1@etf.unsa.ba", "kitkat2015", "password");
            //db.dodaj(k);
            db.dodaj(kk);
            //MessageBox.Show(db.zadnjiId().ToString());
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            View.NarudzbaView s = new View.NarudzbaView();
            Viewmodels.NarudzbaViewModel nvm = new Viewmodels.NarudzbaViewModel();
            s.DataContext = nvm;
            s.Show(); 
           
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            View.O_nama o = new View.O_nama();
            o.Show();
        }
    }
}
