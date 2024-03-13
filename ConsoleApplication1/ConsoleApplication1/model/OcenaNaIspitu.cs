using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Manager.Serialization;

namespace ConsoleApplication1.model
{
    public class OcenaNaIspitu : Serializable, INotifyPropertyChanged
    {
        public int idIspita { get; set; }
        public int idStudenta { get; set; }
        public string sifraPredmeta { get; set; }
        public string SifraPredmeta
        {
            get { return sifraPredmeta; }
            set { sifraPredmeta = value; OnPropertyChanged("Sifra_predmeta_I"); }
        }
        public int ocjena { get; set; }
        public int Ocjena
        {
            get { return ocjena; }
            set { ocjena = value; OnPropertyChanged("Ocjena"); }
        }

        public DateTime datum { get; set; }

        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; OnPropertyChanged("Datum"); }
        }


        public string naziv_predmeta { get; set; }
        public string Naziv_predmeta
        {
            get { return naziv_predmeta; }
            set { naziv_predmeta = value; OnPropertyChanged("Naziv_predmeta_I"); }
        }

        public int broj_ESPB { get; set; }

        public int Broj_ESPB
        {
            get { return broj_ESPB; }
            set { broj_ESPB = value; OnPropertyChanged("Broj_ESPB_I"); }
        }
        public OcenaNaIspitu(int idStudenta, string sifraPredmeta, int ocjena, DateTime datum)
        {
            this.idIspita = 0;
            this.idStudenta = idStudenta;
            this.sifraPredmeta = sifraPredmeta;
            this.ocjena = ocjena;
            this.datum = datum;
            this.broj_ESPB = 0;
            this.naziv_predmeta = "";
            this.naziv_predmeta = "";
        }

        public OcenaNaIspitu() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            
            return String.Format("|IdIspita: {0} \n|IdStudenta: {1} \n|SifraPredmeta: {2} \n|ocjena: {3} \n|datum: {4} \n",idIspita,idStudenta,sifraPredmeta,ocjena,datum);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                idIspita.ToString(),
                idStudenta.ToString(),
                sifraPredmeta.ToString(),
                ocjena.ToString(),
                datum.ToString(),
                naziv_predmeta.ToString(),
                broj_ESPB.ToString(),

            };
           
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            idIspita = int.Parse(values[0]);
            idStudenta=int.Parse(values[1]);
            sifraPredmeta=values[2];
            ocjena = int.Parse(values[3]);
            datum =DateTime.Parse( values[4]);
            naziv_predmeta = values[5];
            broj_ESPB= int.Parse(values[6]);
        }
    }
}
