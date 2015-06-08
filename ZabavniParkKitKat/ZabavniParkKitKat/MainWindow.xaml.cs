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
using System.Windows.Threading;
using Klase;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading;


namespace ZabavniParkKitKat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SerialPort arduinoBoard;

        Thread ts;

        public string username { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Viewmodels.MainWindowViewModel();
         //   arduinoBoard = new SerialPort("COM3");
         //   arduinoBoard.Open();
            
            /*string connectionStringKomentari = "Integrated Security=true;Initial Catalog=KitKat; " + "Data Source=PROBOOK450\\SQLEXPRESS";
            SqlConnection connKomentari = new SqlConnection(connectionStringKomentari);
            connKomentari.Open();*/
            
            //ts.SetApartmentState(ApartmentState.STA);
            try
            {
                arduinoBoard = new SerialPort("COM3");
                arduinoBoard.Open();
                ts = new Thread(arduino);
                ts.IsBackground = true;
                ts.Start();
            }
            catch
            {
                MessageBox.Show("Vanjski uredjaj nije prikljucen!");
            }
            
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
        
        private void fja()
        {
           this.Dispatcher.Invoke(new Action(otvoriMenadzera));
        }
        private void otvoriMenadzera()
        {
            View.MenagerView mv = new View.MenagerView();
            Viewmodels.MenagerViewModel mvm = new Viewmodels.MenagerViewModel();
            mv.DataContext = mvm;
            mv.Show();
        }

        public void arduino()
        {
            string unos = "";
            string pass1 = "123123";
            string pass2 = "232323";
            while (true)
            {
                if (arduinoBoard.IsOpen)
                {
                    if (arduinoBoard.BytesToRead == 1)
                    {
                        unos += (char)arduinoBoard.ReadChar();
                    }
                    if (unos == pass1 || unos == pass2)
                    {
                        fja();
                    }
                    if (unos.Length == 6) unos = "";
                }
                else
                {
                    try
                    {
                        MessageBox.Show("nema ga");
                        arduinoBoard = new SerialPort("COM3");
                        arduinoBoard.Open();
                        unos = "";
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            otvoriMenadzera();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            new View.HelpView().Show();
        }
        
    }
}
