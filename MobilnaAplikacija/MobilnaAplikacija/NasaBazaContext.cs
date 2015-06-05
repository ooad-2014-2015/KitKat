#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobilnaAplikacija
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Data.Linq.Mapping;
using Microsoft.Phone.Data.Linq;


public class DebugWriter : TextWriter
{
    private const int DefaultBufferSize = 256;
    private System.Text.StringBuilder _buffer;

    public DebugWriter()
    {
        BufferSize = 256;
        _buffer = new System.Text.StringBuilder(BufferSize);
    }

    public int BufferSize
    {
        get;
        private set;
    }

    public override System.Text.Encoding Encoding
    {
        get { return System.Text.Encoding.UTF8; }
    }

    #region StreamWriter Overrides
    public override void Write(char value)
    {
        _buffer.Append(value);
        if (_buffer.Length >= BufferSize)
            Flush();
    }

    public override void WriteLine(string value)
    {
        Flush();

        using(var reader = new StringReader(value))
        {
            string line; 
            while( null != (line = reader.ReadLine()))
                System.Diagnostics.Debug.WriteLine(line);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            Flush();
    }

    public override void Flush()
    {
        if (_buffer.Length > 0)
        {
            System.Diagnostics.Debug.WriteLine(_buffer);
            _buffer.Clear();
        }
    }
    #endregion
}


	public partial class NasaBazaContext : System.Data.Linq.DataContext
	{
		
		public bool CreateIfNotExists()
		{
			bool created = false;
			if (!this.DatabaseExists())
			{
				string[] names = this.GetType().Assembly.GetManifestResourceNames();
				string name = names.Where(n => n.EndsWith(FileName)).FirstOrDefault();
				if (name != null)
				{
					using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
					{
						if (resourceStream != null)
						{
							using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
							{
								using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(FileName, FileMode.Create, myIsolatedStorage))
								{
									using (BinaryWriter writer = new BinaryWriter(fileStream))
									{
										long length = resourceStream.Length;
										byte[] buffer = new byte[32];
										int readCount = 0;
										using (BinaryReader reader = new BinaryReader(resourceStream))
										{
											// read file in chunks in order to reduce memory consumption and increase performance
											while (readCount < length)
											{
												int actual = reader.Read(buffer, 0, buffer.Length);
												readCount += actual;
												writer.Write(buffer, 0, actual);
											}
										}
									}
								}
							}
							created = true;
						}
						else
						{
							this.CreateDatabase();
							created = true;
						}
					}
				}
				else
				{
					this.CreateDatabase();
					created = true;
				}
			}
			return created;
		}
		
		public bool LogDebug
		{
			set
			{
				if (value)
				{
					this.Log = new DebugWriter();
				}
			}
		}
		
		public static string ConnectionString = "Data Source=isostore:/NasaBaza.sdf";

		public static string ConnectionStringReadOnly = "Data Source=appdata:/NasaBaza.sdf;File Mode=Read Only;";

		public static string FileName = "NasaBaza.sdf";

		public NasaBazaContext(string connectionString) : base(connectionString)
		{
			OnCreated();
		}
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNasaTabelicaAtrakcija(NasaTabelicaAtrakcija instance);
    partial void UpdateNasaTabelicaAtrakcija(NasaTabelicaAtrakcija instance);
    partial void DeleteNasaTabelicaAtrakcija(NasaTabelicaAtrakcija instance);
    #endregion
		
		public System.Data.Linq.Table<NasaTabelicaAtrakcija> NasaTabelicaAtrakcija
		{
			get
			{
				return this.GetTable<NasaTabelicaAtrakcija>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute()]
	public partial class NasaTabelicaAtrakcija : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Naziv;
		
		private string _TipAtrakcije;
		
		private string _OpisAtrakcije;
		
		private int _Ocjena;
		
		private int _Kapacitet;
		
		private System.Data.Linq.Binary _Slika;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNazivChanging(string value);
    partial void OnNazivChanged();
    partial void OnTipAtrakcijeChanging(string value);
    partial void OnTipAtrakcijeChanged();
    partial void OnOpisAtrakcijeChanging(string value);
    partial void OnOpisAtrakcijeChanged();
    partial void OnOcjenaChanging(int value);
    partial void OnOcjenaChanged();
    partial void OnKapacitetChanging(int value);
    partial void OnKapacitetChanged();
    partial void OnSlikaChanging(System.Data.Linq.Binary value);
    partial void OnSlikaChanged();
    #endregion
		
		public NasaTabelicaAtrakcija()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Naziv", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if ((this._Naziv != value))
				{
					this.OnNazivChanging(value);
					this.SendPropertyChanging();
					this._Naziv = value;
					this.SendPropertyChanged("Naziv");
					this.OnNazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipAtrakcije", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string TipAtrakcije
		{
			get
			{
				return this._TipAtrakcije;
			}
			set
			{
				if ((this._TipAtrakcije != value))
				{
					this.OnTipAtrakcijeChanging(value);
					this.SendPropertyChanging();
					this._TipAtrakcije = value;
					this.SendPropertyChanged("TipAtrakcije");
					this.OnTipAtrakcijeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpisAtrakcije", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
		public string OpisAtrakcije
		{
			get
			{
				return this._OpisAtrakcije;
			}
			set
			{
				if ((this._OpisAtrakcije != value))
				{
					this.OnOpisAtrakcijeChanging(value);
					this.SendPropertyChanging();
					this._OpisAtrakcije = value;
					this.SendPropertyChanged("OpisAtrakcije");
					this.OnOpisAtrakcijeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ocjena", DbType="Int NOT NULL")]
		public int Ocjena
		{
			get
			{
				return this._Ocjena;
			}
			set
			{
				if ((this._Ocjena != value))
				{
					this.OnOcjenaChanging(value);
					this.SendPropertyChanging();
					this._Ocjena = value;
					this.SendPropertyChanged("Ocjena");
					this.OnOcjenaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Kapacitet", DbType="Int NOT NULL")]
		public int Kapacitet
		{
			get
			{
				return this._Kapacitet;
			}
			set
			{
				if ((this._Kapacitet != value))
				{
					this.OnKapacitetChanging(value);
					this.SendPropertyChanging();
					this._Kapacitet = value;
					this.SendPropertyChanged("Kapacitet");
					this.OnKapacitetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Slika", DbType="Image NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Slika
		{
			get
			{
				return this._Slika;
			}
			set
			{
				if ((this._Slika != value))
				{
					this.OnSlikaChanging(value);
					this.SendPropertyChanging();
					this._Slika = value;
					this.SendPropertyChanged("Slika");
					this.OnSlikaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
