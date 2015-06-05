using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace MobilnaAplikacija
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
            using (NasaBazaContext db = new NasaBazaContext(NasaBazaContext.ConnectionString))
            {
                db.CreateIfNotExists();
                try
                {
                    Table<NasaTabelicaAtrakcija> atrakcije = db.GetTable<NasaTabelicaAtrakcija>();
                    var atrakcijeQuery = from a in atrakcije.ToList() select a;
                    foreach (var atrakcija in atrakcijeQuery)
                    {
                        PivotItem p = new PivotItem();
                        AtrakcijaKontrola atrakcijaKontrola = new AtrakcijaKontrola();
                        atrakcijaKontrola.Naziv.Text =atrakcija.Naziv;
                        atrakcijaKontrola.Opis.Text = atrakcija.OpisAtrakcije;
                        atrakcijaKontrola.Kapacitet.Text = "Kapacitet: "+atrakcija.Kapacitet.ToString();
                        atrakcijaKontrola.Ocjena.Text = "Ocjena: "+atrakcija.Ocjena.ToString();
                        atrakcijaKontrola.Tip.Text = "Tip: "+atrakcija.TipAtrakcije;
                        if (atrakcija.Slika.ToArray() != null && atrakcija.Slika.ToArray() is Byte[])
                        {
                            MemoryStream stream = new MemoryStream(atrakcija.Slika.ToArray());
                            BitmapImage image = new BitmapImage();
                            image.SetSource(stream);
                            atrakcijaKontrola.Slika.Source = image;
                        }
                        p.Header = "Atrakcija"; //jelo.Ime;
                        p.Content = atrakcijaKontrola;
                        p.Width = 578;
                        mojPivot.Items.Add(p);
                    }

                }
                catch (Exception et)
                {

                }
            }
        }

        private void mojPivot_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}