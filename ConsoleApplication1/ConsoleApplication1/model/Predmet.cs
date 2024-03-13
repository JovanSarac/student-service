using System;
using ConsoleApplication1.Manager.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;
using ConsoleApplication1.Manager;

namespace ConsoleApplication1.model
{
   public enum Semestar {letnji,zimski};

    public class Predmet : Serializable, INotifyPropertyChanged
    {

        public string sifra_predmeta { get; set; }

        public string Sifra_predmeta
        {
            get { return sifra_predmeta; }
            set { sifra_predmeta = value; OnPropertyChanged("Sifra_predmeta"); }
        }
        public string naziv_predmeta { get; set; }

        public string Naziv_predmeta
        {
            get { return naziv_predmeta; }
            set { naziv_predmeta = value; OnPropertyChanged("Naziv_predmeta"); }
        }
        public Semestar semestar { get; set; }

        public Semestar Semestar
        {
            get { return semestar; }
            set { semestar = value; OnPropertyChanged("Semestar"); }
        }
        public int godina_studija_ukojoj_se_predmet_izvodi { get; set; }

        public int Godina_studija_ukojoj_se_predmet_izvodi
        {
            get { return godina_studija_ukojoj_se_predmet_izvodi; }
            set { godina_studija_ukojoj_se_predmet_izvodi = value; OnPropertyChanged("Godina_studija_ukojoj_se_predmet_izvodi"); }
        }

        public string predmetni_profesor { get; set; }
        public int broj_ESPB { get; set; }

        public int Broj_ESPB
        {
            get { return broj_ESPB; }
            set { broj_ESPB = value; OnPropertyChanged("Broj_ESPB"); }
        }

        public List<Student> studenti_koji_su_polozili;
        public List<Student> studenti_koji_nisu_polozili;
        public Predmet() {
            studenti_koji_su_polozili = new List<Student>();
            studenti_koji_nisu_polozili = new List<Student>();
        }

        public Predmet(String sif, String naz, Semestar s, int gukspi, String prof, int brse)
        {
            sifra_predmeta = sif;
            naziv_predmeta = naz;
            semestar = s;
            godina_studija_ukojoj_se_predmet_izvodi = gukspi;
            predmetni_profesor = "";
            broj_ESPB = brse;
            studenti_koji_su_polozili = new List<Student>();
            studenti_koji_nisu_polozili = new List<Student>();
        }


        public override string ToString()
        {
            return String.Format("|Sifra predmeta: {0} \n|Naziv: {1} \n|Semestar: {2} \n|Godina studija u kojoj se predmet izvodi: {3} \n|Predmetni profesor: {4} \n|Broj ESPB bodova: {5}  ",  sifra_predmeta, naziv_predmeta, semestar, godina_studija_ukojoj_se_predmet_izvodi, predmetni_profesor, broj_ESPB );
        }


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                
                sifra_predmeta,
                naziv_predmeta,
                semestar.ToString(),
                godina_studija_ukojoj_se_predmet_izvodi.ToString(),
                predmetni_profesor.ToString(),
                broj_ESPB.ToString(),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            sifra_predmeta = values[0];
            naziv_predmeta = values[1];
            string sem = values[2];
            if (sem == "letnji")
            {
                semestar = Semestar.letnji;
            }else if(sem == "zimski")
            {
                semestar = Semestar.zimski;
            }
            godina_studija_ukojoj_se_predmet_izvodi = int.Parse(values[3]);
            predmetni_profesor = values[4];
            broj_ESPB = int.Parse(values[5]);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //VALIDACIJA PREDMETA
        private Regex _RegexESPB = new Regex("^[1-9]{1}$");

        public string IsValid(Predmet p)
        {
            
            if (string.IsNullOrEmpty(p.naziv_predmeta))
            {
                return "Morate unijeti neke podatke za naziv predmeta!";
            }

            if (p.godina_studija_ukojoj_se_predmet_izvodi == -1)
            {
                return "Morate unijeti neke podatke za godinu studija u kojoj se predmet izvodi!";
            }

           /* if (string.IsNullOrEmpty(p.predmetni_profesor))
            {
                return "Morate unijeti neke podatke za predmetnog profesora!";
            }*/

            if (p.broj_ESPB == -1)
            {
                return "Morate unijeti neke podatke za broj ESPB bodova predmeta!";
            }else
            {
                Match match = _RegexESPB.Match(p.broj_ESPB.ToString());
                if (!match.Success)
                    return "Broj ESPB bodova mora biti u rasponu od 1-9!";
            }


            return null;

        }
    }
}
