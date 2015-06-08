using Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ZabavniParkKitKat.DAL
{
    class DataBaseZahtjevi:DataBase
    {
        public DataBaseZahtjevi(string password, string server = "local", string username = "Amar", string database = "KitKat"): base(password, server, username, database)
        {

        }
        public ObservableCollection<ZahtjevZaSastanak> dajSve()
        {
            ObservableCollection<ZahtjevZaSastanak> atrakcije = new ObservableCollection<ZahtjevZaSastanak>();
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Zahtjevi";
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                            atrakcije.Add(new ZahtjevZaSastanak(Convert.ToInt32(r[0].ToString()),r[1].ToString(),r[2].ToString(),r[3].ToString(),(DateTime)r[4]));
                }
                connection.Close();
                return atrakcije;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return atrakcije;
            }
        }
        public ObservableCollection<ZahtjevZaSastanak> dajSveNaCekanju()
        {
            ObservableCollection<ZahtjevZaSastanak> atrakcije = new ObservableCollection<ZahtjevZaSastanak>();
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Zahtjevi where Status='Na cekanju'";
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    atrakcije.Add(new ZahtjevZaSastanak(Convert.ToInt32(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[3].ToString(), (DateTime)r[4]));
                }
                connection.Close();
                return atrakcije;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return atrakcije;
            }
        }
        public void prihvati(int id)
        {
            //ZahtjevZaSastanak ZahtjevZaSastanak;
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "update Zahtjevi set Status='Prihvacen' where Id=@broj";
                upit.Parameters.AddWithValue("@broj", id);
                upit.Parameters.AddWithValue("@s", "Prihvacen");
                upit.ExecuteNonQuery();
                connection.Close();
                return;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return;
            }
            finally
            {
                connection.Close();
            }
        }

        public void odbij(int id)
        {
            //ZahtjevZaSastanak ZahtjevZaSastanak;
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "update Zahtjevi set Status='Odbijen' where Id=@broj";
                upit.Parameters.AddWithValue("@broj", id);
                upit.Parameters.AddWithValue("@s", "Prihvacen");
                upit.ExecuteNonQuery();
                connection.Close();
                return;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return;
            }
            finally
            {
                connection.Close();
            }
        }

        public ObservableCollection<ZahtjevZaSastanak> dajPoIduFirme(int id)
        {
            ObservableCollection<ZahtjevZaSastanak> atrakcije = new ObservableCollection<ZahtjevZaSastanak>();
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Zahtjevi where IdKompanije=@Id";
                upit.Parameters.AddWithValue("@Id", id);
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    atrakcije.Add(new ZahtjevZaSastanak(Convert.ToInt32(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[3].ToString(), (DateTime)r[4]));
                }
                connection.Close();
                return atrakcije;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return atrakcije;
            }
        }

        public int zadnjiId()
        {
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select Max(id) from Zahtjevi";
               // upit.Parameters.AddWithValue("@ime", username);
                SqlDataReader r = upit.ExecuteReader();
                int vrati=0;
                while (r.Read())
                {
                    vrati = Convert.ToInt32(r[0].ToString());
                }
                return vrati;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool dodaj(Object o,int IdFirme)
        {
            try
            {
                ZahtjevZaSastanak objekat = o as ZahtjevZaSastanak;
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into Zahtjevi values(@id, @Naziv, @Obrazlozenje, @Status,@Datum,@IdFirme);";
                upit.Parameters.AddWithValue("@id", objekat.Id);
                upit.Parameters.AddWithValue("@Naziv", objekat.NazivProizvoda);
                upit.Parameters.AddWithValue("@Obrazlozenje", objekat.Obrazlozenje);
                upit.Parameters.AddWithValue("@Status", objekat.Status);
                upit.Parameters.AddWithValue("@Datum", objekat.DatumSastanka);
                upit.Parameters.AddWithValue("@IdFirme", IdFirme);
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
