
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace ZabavniParkKitKat.DAL
{
    public class DataBaseArtikli : DataBase
    {
        public DataBaseArtikli(string password, string server = "ACER\\SQLEXPRESS", string username = "acer\\Gebruiker", string database = "KitKat")
            : base(password, server, username, database)
        {

        }
      
        public ObservableCollection<Klase.Proizvod> dajSve()
        {
            ObservableCollection<Klase.Proizvod> artikli = new ObservableCollection<Klase.Proizvod>();
            //MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Artikli";
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    {

                       {
                            BitmapImage slika = byteArrayToImage((byte[])r[3]);
                            artikli.Add(new Klase.Proizvod(Convert.ToInt32(r[0]),Convert.ToInt32(r[4]),r[2].ToString(),r[1].ToString(),slika));
                           //id,cijena,tip,ime,slike
                        }
                    }
                }
                connection.Close();
                return artikli;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return artikli;
            }
        }
        public ObservableCollection<Klase.Proizvod> dajFotografije()
        {
            ObservableCollection<Klase.Proizvod> artikli = new ObservableCollection<Klase.Proizvod>();
            //MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Artikli where Tip='Photo'";
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    {

                        {
                            BitmapImage slika = byteArrayToImage((byte[])r[3]);
                            artikli.Add(new Klase.Proizvod(Convert.ToInt32(r[0]), Convert.ToInt32(r[4]), r[2].ToString(), r[1].ToString(), slika));
                            //id,cijena,tip,ime,slike
                        }
                    }
                }
                connection.Close();
                return artikli;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return artikli;
            }
        }

        public ObservableCollection<Klase.Proizvod> dajSuvenire()
        {
            ObservableCollection<Klase.Proizvod> artikli = new ObservableCollection<Klase.Proizvod>();
            //MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Artikli where Tip='Suvenir'";
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    {

                        {
                            BitmapImage slika = byteArrayToImage((byte[])r[3]);
                            artikli.Add(new Klase.Proizvod(Convert.ToInt32(r[0]), Convert.ToInt32(r[4]), r[2].ToString(), r[1].ToString(), slika));
                            //id,cijena,tip,ime,slike
                        }
                    }
                }
                connection.Close();
                return artikli;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return artikli;
            }
        }

        
/*
        public bool dodaj(Object o)
        {
            MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                long id_specifikacije = 0;
                Artikal objekat = o as Artikal;
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into specifikacije(godina_proizvodnje, proizvodjac, model, materijal) values(@godina_proizvodnje, @proizvodjac, @model, @materijal)";
                upit.Parameters.AddWithValue("@godina_proizvodnje", objekat.Spec.GodinaProizvodnje);
                upit.Parameters.AddWithValue("@proizvodjac", objekat.Spec.Proizvodjac);
                upit.Parameters.AddWithValue("@model", objekat.Spec.Model);
                upit.Parameters.AddWithValue("@materijal", objekat.Spec.Materijal);
                upit.ExecuteNonQuery();
                id_specifikacije = upit.LastInsertedId;
                if (objekat is ElektricnaGitara)
                {
                    ElektricnaGitara ob = o as ElektricnaGitara;
                    SpecElektricna temp = ob.SpecEl;
                    upit.CommandText = "insert into spec_gitara values(@id, @masinica, @vrat, @most, @pickup, @elektronika, @broj_zica)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@masinica", null);
                    upit.Parameters.AddWithValue("@vrat", temp.Vrat);
                    upit.Parameters.AddWithValue("@most", temp.Most);
                    upit.Parameters.AddWithValue("@pickup", temp.PickUp);
                    upit.Parameters.AddWithValue("@elektronika", temp.Elektronika);
                    upit.Parameters.AddWithValue("@broj_zica", temp.BrojZica);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", ob.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", ob.Naziv);
                    upit.Parameters.AddWithValue("@cijena", ob.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(ob.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 1);
                    if (((ElektricnaGitara)(ob)).Tip == TipElektronika.Elektricna) upit.Parameters.AddWithValue("@tip_gitare", 3);
                    else upit.Parameters.AddWithValue("@tip_gitare", 4);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is KlasicnaGitara)
                {
                    KlasicnaGitara git = o as KlasicnaGitara;
                    SpecKlasicna temp = git.SpecKL;
                    upit.CommandText = "insert into spec_gitara values(@id, @masinica, @vrat, @most, @pickup, @elektronika, @broj_zica)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@masinica", temp.Masinica);
                    upit.Parameters.AddWithValue("@vrat", null);
                    upit.Parameters.AddWithValue("@most", null);
                    upit.Parameters.AddWithValue("@pickup", null);
                    upit.Parameters.AddWithValue("@elektronika", null);
                    upit.Parameters.AddWithValue("@broj_zica", temp.BrojZica);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", git.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", git.Naziv);
                    upit.Parameters.AddWithValue("@cijena", git.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(git.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 2);
                    if (((KlasicnaGitara)(git)).Tip == TipKlasicne.Akusticna) upit.Parameters.AddWithValue("@tip_gitare", 2);
                    else upit.Parameters.AddWithValue("@tip_gitare", 1);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is Klavijatura)
                {
                    Klavijatura oo = o as Klavijatura;
                    SpecKlavijatura temp = oo.SpecKl;
                    upit.CommandText = "insert into spec_klavijature values(@id, @broj_tipki, @zvucnik, @tezina, @napajanje)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@broj_tipki", temp.BrojTipki);
                    upit.Parameters.AddWithValue("@zvucnik", temp.Zvucnik);
                    upit.Parameters.AddWithValue("@tezina", temp.Tezina);
                    upit.Parameters.AddWithValue("@napajanje", temp.Napajanje);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", oo.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", oo.Naziv);
                    upit.Parameters.AddWithValue("@cijena", oo.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(oo.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 3);
                    upit.Parameters.AddWithValue("@tip_gitare", null);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is Pojacalo)
                {
                    Pojacalo oo = o as Pojacalo;
                    SpecPojacalo temp = oo.SpecPo as SpecPojacalo;
                    upit.CommandText = "insert into spec_pojacala values(@id, @zvucnik, @broj_kanala, @ulaz_slusalice)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@zvucnik", temp.Zvucnik);
                    upit.Parameters.AddWithValue("@broj_kanala", temp.BrojKanala);
                    upit.Parameters.AddWithValue("@ulaz_slusalice", temp.UlazZaSlusalice);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", oo.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", oo.Naziv);
                    upit.Parameters.AddWithValue("@cijena", oo.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(oo.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 4);
                    upit.Parameters.AddWithValue("@tip_gitare", null);
                    upit.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                connection2.Close();
                return false;
            }
        }

        public bool obrisi(Artikal objekat)
        {
            try
            {
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from artikli where serijski_broj = @sBroj";
                upit.Parameters.AddWithValue("@sBroj", objekat.SerijskiBroj);
                upit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }
        public bool obrisi(int sBroj)
        {
            try
            {
                connection.Open();
                uint id_spec = 0;
                string tipArtikla = String.Empty;
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from artikli where serijski_broj = @sBroj";
                upit.Parameters.AddWithValue("@sBroj", sBroj);
                MySqlDataReader r = upit.ExecuteReader();
                r.Read();
                id_spec = r.GetUInt32("id_specifikacije");
                tipArtikla = r.GetString("tip_artikla");

                r.Close();

                upit.CommandText = "delete from artikli where serijski_broj = @sBroj";
                //upit.Parameters.AddWithValue("@sBroj", sBroj);
                upit.ExecuteNonQuery();

                //klavijature
                if (tipArtikla == "Klavijatura")
                {
                    upit.CommandText = "delete from spec_klavijature where id_spec = @specBroj";
                    upit.Parameters.AddWithValue("@specBroj", id_spec);
                    upit.ExecuteNonQuery();
                }
                else if (tipArtikla == "KlasicnaGitara" || tipArtikla == "ElektricnaGitara")
                {
                    upit.CommandText = "delete from spec_gitara where id_spec = @specBroj";
                    upit.Parameters.AddWithValue("@specBroj", id_spec);
                    upit.ExecuteNonQuery();
                }
                else if (tipArtikla == "Pojacalo")
                {
                    upit.CommandText = "delete from spec_gitara where id_spec = @specBroj";
                    upit.Parameters.AddWithValue("@specBroj", id_spec);
                    upit.ExecuteNonQuery();
                }
                upit.CommandText = "delete from specifikacije where id_spec = @specBroj";
                upit.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }
        public bool daLiPostoji(Artikal objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from artikli where serijski_broj = @sBroj";
                upit.Parameters.AddWithValue("@sBroj", objekat.SerijskiBroj);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    if (r.GetInt32("serijski_broj") == objekat.SerijskiBroj)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
                return false;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

*/
        public BitmapImage byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(byteArrayIn))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }

    
    }
}
