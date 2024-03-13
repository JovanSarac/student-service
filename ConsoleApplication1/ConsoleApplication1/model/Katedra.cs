using ConsoleApplication1.Manager.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.model
{
    public class Katedra : Serializable, INotifyPropertyChanged
    {
        public int sifra_katedre { get; set; }
        public int Sifra_katedre
        {
            get { return sifra_katedre; }
            set { sifra_katedre = value; OnPropertyChanged("Sifra_katedre"); }
        }
        public string naziv_katedre { get; set; }
        public string Naziv_katedre
        {
            get { return naziv_katedre; }
            set { naziv_katedre = value; OnPropertyChanged("Naziv_katedre"); }
        }
        public int idSefaKatedra { get; set; }
        public int IdSefaKatedre
        {
            get { return idSefaKatedra; }
            set { idSefaKatedra = value; OnPropertyChanged("Id_sefa_katedre"); }

        }

        public Profesor sef_katedre;
        public List<Profesor> profesori_na_katedri;


        public Katedra()
        {
            sef_katedre = new Profesor();
            profesori_na_katedri = new List<Profesor>();
        }

        public override string ToString()
        {
            return String.Format("|Sifra katedre: {0} \n|Naziv katedre: {1} \n ", sifra_katedre, naziv_katedre);
        }



        public string[] ToCSV()
        {
            string[] csvValues =
            {
                sifra_katedre.ToString(),
                naziv_katedre,
                idSefaKatedra.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            sifra_katedre =int.Parse( values[0]);
            naziv_katedre = values[1];   
            idSefaKatedra = int.Parse(values[2]);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
