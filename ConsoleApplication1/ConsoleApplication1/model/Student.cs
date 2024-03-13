using ConsoleApplication1.Manager.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public enum Status { B, S };
namespace ConsoleApplication1.model
{

    public class Student : Serializable, INotifyPropertyChanged
    {
        
        public int Id { get; set; }
        public string ime { get; set; }

        public string Ime
        {
            get { return ime; }
            set { broj_indeksa = value; OnPropertyChanged("Ime"); }
        }

        public string prezime { get; set; }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }
        public DateTime datum_rodjenja { get; set; }
        public int adresa_stanovanja_id { get; set; }
        public Adresa adresa_studenta{ get; set; }

        public string adresas { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public string broj_indeksa { get; set; }

        public string Broj_indeksa
        {
            get { return broj_indeksa; }
            set { broj_indeksa = value; OnPropertyChanged("Broj_indeksa"); }
        }
        public int godina_upisa { get; set; }
        public int trenutna_godina_studija { get; set; }

        public int Trenutna_godina_studija
        {
            get { return trenutna_godina_studija; }
            set { trenutna_godina_studija = value; OnPropertyChanged("Trenutna_godina_studija"); }
        }
        public Status nacin_finansiranja { get; set; }

        public Status Nacin_finansiranja
        {
            get { return nacin_finansiranja; }
            set { nacin_finansiranja = value; OnPropertyChanged("Nacin_finansiranja"); }
        }

        public double prosecna_ocena { get; set; }

        public double Prosecna_ocena
        {
            get { return prosecna_ocena; }
            set { prosecna_ocena = value; OnPropertyChanged("Prosecna_ocena"); }

        }


        public List<Predmet> polozeniPredmeti;

        public List<Predmet> nepolozeniPredmeti;


        

        public Student(int id, string i,string p,DateTime dt,string ads,string tel,string em,string bri,int gu,int tgu,Status s)
        {
            Id = id;
            ime = i;
            prezime = p;
            datum_rodjenja = dt;
            adresas = ads;
            telefon = tel;
            email = em;
            broj_indeksa = bri;
            godina_upisa = gu;
            trenutna_godina_studija = tgu;
            nacin_finansiranja = s;
            
            polozeniPredmeti = new List<Predmet>();
            nepolozeniPredmeti= new List<Predmet>();
            adresa_studenta = new Adresa();
        }

        public Student() {
            polozeniPredmeti = new List<Predmet>();
            nepolozeniPredmeti = new List<Predmet>();
            adresa_studenta = new Adresa();
        }

        public override string ToString()
        {
            return String.Format("|ID: {0} \n|Ime: {1} \n|Prezime: {2} \n|Datum rodjenja: {3} \n|Adresa stanovanja: {4} \n|Telefon: {5} \n|Email adresa: {6} \n|Broj indeksa: {7} \n|Godina upisa: {8}\n|Trenutna godina studija: {9} \n|Nacin finansiranja: {10} \n|Prosecna ocena: {11} ",Id, ime, prezime, datum_rodjenja, adresas, telefon, email, broj_indeksa, godina_upisa, trenutna_godina_studija, nacin_finansiranja, prosecna_ocena);
        }


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                ime,
                prezime,
                datum_rodjenja.ToString(),
// adresa_stanovanja_id.ToString(),
                adresas,
                telefon,
                email,
                broj_indeksa,
                godina_upisa.ToString(),
                trenutna_godina_studija.ToString(),
                nacin_finansiranja.ToString(),
                prosecna_ocena.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            ime = values[1];
            prezime = values[2];
            datum_rodjenja = DateTime.Parse(values[3]);
            //adresa_stanovanja_id =int.Parse(values[4]);

            adresas = values[4];    
            telefon = values[5];
            email = values[6];
            broj_indeksa = values[7];
            godina_upisa = int.Parse(values[8]);
            trenutna_godina_studija = int.Parse(values[9]);
            string nf = values[10];
            
            if (nf == "B")
            {
                nacin_finansiranja = Status.B;
            } else if (nf == "S") {
                nacin_finansiranja = Status.S;
            }

          
            prosecna_ocena = double.Parse(values[11]);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        //VALIDACIJA STUDENTA
        private Regex _GodinaRegex = new Regex("[0-9]{4}");
        private Regex _IndexRegex = new Regex("[A-Z]{2} [0-9]{1,3}/[0-9]{4}");
        private Regex _RegexImePrz = new Regex("^[A-Z]{1}[a-z]{1,19}$");
        private Regex _RegexTelefon = new Regex("[0-9]{3}/[0-9]{7}");
        private Regex _RegexEmail = new Regex("[a-z]{1,20}\\.[a-z]{2}[0-9]{1,3}\\.[0-9]{4}@uns.ac.rs");

        public string IsValid(Student s)
        {

            if (string.IsNullOrEmpty(s.ime))
            {
                return "Morate unijeti neke podatke za ime studenta";
            }else
            {
                Match match = _RegexImePrz.Match(s.ime);
                if (!match.Success)
                    return "Ime mora biti sastavljeno od slova i mora zapoceti velikim pocetnim slovoom(minimalno 1 a maksimalno 20)!";
            }

            if (string.IsNullOrEmpty(s.prezime))
            {
                return "Morate unijeti neke podatke za prezime studenta";
            }else
            {
                Match match = _RegexImePrz.Match(s.prezime);
                if (!match.Success)
                    return "Prezime mora biti sastavljeno od slova i mora zapoceti velikim pocetnim slovoom(minimalno 1 a maksimalno 20)!";
            }

            if (string.IsNullOrEmpty(s.datum_rodjenja.ToString()))
            {
                return "Morate unijeti neke podatke za datum rodjenja studenta";
            }

            if (string.IsNullOrEmpty(s.adresas))
            {
                return "Morate unijeti neke podatke za adresu stanovanja studenta";
            }

            if (string.IsNullOrEmpty(s.telefon))
            {
                return "Morate unijeti neke podatke za broj telefona studenta";
            }
            else
            {
                Match match = _RegexTelefon.Match(s.telefon);
                if (!match.Success)
                    return "Broj telefona mora biti u obliku yyy/1234567!";
            }

            if (string.IsNullOrEmpty(s.email))
            {
                return "Morate unijeti neke podatke za email studenta";
            }
            else
            {
                Match match = _RegexEmail.Match(s.email);
                if (!match.Success)
                    return "Email mora da bude u sledecem formatu xxxxx.yy123.yyyy@uns.ac.rs!";
            }

            if (string.IsNullOrEmpty(s.broj_indeksa))
            {
                return "Morate unijeti neke podatke za  broj indeksa studenta";
            }else
            {
                Match match = _IndexRegex.Match(s.broj_indeksa);
                if (!match.Success)
                    return "Broj indeksa mora biti u formatu XY 123/YYYY!";
            }

            if (s.godina_upisa == 0)
            {
                return "Morate unijeti neke validne podatke za  godinu upisa studenta";
            }else
            {
                Match match = _GodinaRegex.Match(s.godina_upisa.ToString());
                if (!match.Success)
                    return "Godina upisa mora biti sastavljena od 4 cifre";
            }

            if (s.trenutna_godina_studija == 0)
            {
                return "Morate unijeti neke podatke za trenutnu godinu studija studenta";
            }

            return null;
            
        }

    }
}
