using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klase;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;

namespace ZabavniParkKitKat.DAL
{
    class DataBaseKompanije:DataBase
    {
        public DataBaseKompanije(string password, string server = "local", string username = "Amar", string database = "KitKat"): base(password, server, username, database)
        {

        }
        public ObservableCollection<Kompanija> dajSve()
        {
            ObservableCollection<Kompanija> atrakcije = new ObservableCollection<Kompanija>();
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Kompanije";
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                            atrakcije.Add(new Kompanija(Convert.ToInt32(r[0].ToString()),r[1].ToString(),r[2].ToString(),r[3].ToString(),r[4].ToString()));
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
        public Kompanija dajPoUsernameU(string username)
        {
            Kompanija kompanija;
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText ="select * from Kompanije where username=@ime" ;
                upit.Parameters.AddWithValue("@ime",username);
                SqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    kompanija = new Kompanija(Convert.ToInt32(r[0].ToString()), r[1].ToString(), r[2].ToString(), r[3].ToString(), r[4].ToString());
                    return kompanija;
                }
                return null;
            }
            catch (Exception)
            {
                connection.Close();
                //connection2.Close();
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

        public int zadnjiId()
        {
            try
            {
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select Max(id) from Kompanije";
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
        public bool dodaj(Object o)
        {
            try
            {
                Kompanija objekat = o as Kompanija;
                connection.Open();
                SqlCommand upit = new SqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into Kompanije values(@id, @Naziv, @Email, @Username,@Password);";
                upit.Parameters.AddWithValue("@id", objekat.Id);
                upit.Parameters.AddWithValue("@Naziv", objekat.Naziv);
                upit.Parameters.AddWithValue("@Email", objekat.Email);
                upit.Parameters.AddWithValue("@Username", objekat.Username);
                upit.Parameters.AddWithValue("@Password", objekat.Password);
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
