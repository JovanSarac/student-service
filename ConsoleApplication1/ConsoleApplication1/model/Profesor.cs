using System;
using ConsoleApplication1.Manager.Serialization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1.model
{
    public class Profesor : Serializable, INotifyPropertyChanged
    {

        public int Id { get; set; }
        public int ID
        {
            get { return Id; }
            set { Id = value; OnPropertyChanged("Id"); }
        }
        public string prezime { get; set; }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }
        public string ime { get; set; }

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }
        public DateTime datum_rodjenja { get; set; }
        public int adresa_stanovanja_id { get; set; }

        public Adresa adresa_profesora { get; set; }

        public string adresap { get; set; }
        public string kontakt_telefon { get; set; }

        public string Kontakt_telefon
        {
            get { return kontakt_telefon; }
            set { kontakt_telefon = value; OnPropertyChanged("Kontakt_telefon"); }
        }
        public string email { get; set; }

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }
        public int adresa_kancelarije_id { get; set; }

        public Adresa adresa_kancelarije { get; set; }

        public string adresak { get; set; }

        public string broj_licne { get ;  set ;  }

        public string Broj_licne
        {
            get { return broj_licne; }
            set { broj_licne = value; OnPropertyChanged("Broj_licne"); }
        }
        public string zvanje { get; set; }

        public string Zvanje
        {
            get { return zvanje; }
            set { zvanje = value; OnPropertyChanged("Zvanje"); }
        }
        public int godine_staza { get; set; }

        public List<Predmet> predmeti_gdje_predaje { get; set; }

        public int id_katedre { get; set; }




        public Profesor(int id, string i, string p, DateTime dt, string ads, string tel, string em, string adkid, string brl, string zv, int gs, int idk)
        {
            Id = id;
            ime = i;
            prezime = p;
            datum_rodjenja = dt;
            adresap = ads;
            Kontakt_telefon = tel;
            email = em;
            adresak = adkid;
            broj_licne = brl;
            zvanje = zv;
            godine_staza = gs;
            id_katedre = idk;

            Adresa adresa_profesora = new Adresa();
            Adresa adresa_kancelarije = new Adresa();
            List<Predmet> predmeti_gdje_predaje = new List<Predmet>();



        }
        public Profesor(string prezime, string ime, string zvanje, string email)
        {

            this.prezime = prezime;
            this.ime = ime;
            this.zvanje = zvanje;
            this.email = email;

        }


        public Profesor() {
            predmeti_gdje_predaje = new List<Predmet>();
        }

        public override string ToString()
        {
            return String.Format("|ID: {0} \n|Ime: {1} \n|Prezime: {2} \n|Datum rodjenja: {3} \n|Adresa stanovanja: {4} \n|Kontakt telefon: {5} \n|Email adresa: {6} \n|Adresa kancelarije: {7} \n|Broj licne karte: {8}\n|Zvanje: {9} \n|Godine staza: {10}  ", Id, ime, prezime, datum_rodjenja, adresap, kontakt_telefon, email, adresak, broj_licne, zvanje, godine_staza);
        }




        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                ime,
                prezime,
                datum_rodjenja.ToString(),
                adresap.ToString(),
                kontakt_telefon,
                email,
                adresak.ToString(),
                broj_licne,
                zvanje,
                godine_staza.ToString(),
                id_katedre.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            ime = values[1];
            prezime = values[2];
            datum_rodjenja = DateTime.Parse(values[3]);
            adresap =values[4];
            kontakt_telefon = values[5];
            email = values[6];
            adresak =values[7];
            broj_licne = values[8];
            zvanje = values[9];
            godine_staza = int.Parse(values[10]);
            id_katedre = int.Parse(values[11]);
            
        }


       

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        //VALIDACIJA PROFESORA
        private Regex _GodinaRegex = new Regex("^[0-9]{1,2}?$");
        private Regex _RegexImePrz = new Regex("^[A-Z]{1}[a-z]{1,19}$");
        private Regex _RegexTelefon = new Regex("[0-9]{3}/[0-9]{7}");
        private Regex _RegexEmail = new Regex("[a-z]{1,20}\\.[a-z]{0,20}@uns.ac.rs");

        public string IsValid(Profesor p)
        {

            if (string.IsNullOrEmpty(p.ime))
            {
                return "Morate unijeti neke podatke za ime profesora";
            }
            else
            {
                Match match = _RegexImePrz.Match(p.ime);
                if (!match.Success)
                    return "Ime mora biti sastavljeno od slova i mora zapoceti velikim pocetnim slovoom(minimalno 1 a maksimalno 20)!";
            }

            if (string.IsNullOrEmpty(p.prezime))
            {
                return "Morate unijeti neke podatke za prezime profesora";
            }
            else
            {
                Match match = _RegexImePrz.Match(p.prezime);
                if (!match.Success)
                    return "Prezime mora biti sastavljeno od slova i mora zapoceti velikim pocetnim slovoom(minimalno 1 a maksimalno 20)!";
            }

            /*if (string.IsNullOrEmpty(p.datum_rodjenja.ToString()))
            {
                return "Morate unijeti neke podatke za datum rodjenja profesora";
            }*/

            if (string.IsNullOrEmpty(p.adresap))
            {
                return "Morate unijeti neke podatke za adresu stanovanja profesora";
            }

            if (string.IsNullOrEmpty(p.kontakt_telefon))
            {
                return "Morate unijeti neke podatke za broj telefona profesora";
            }
            else
            {
                Match match = _RegexTelefon.Match(p.kontakt_telefon);
                if (!match.Success)
                    return "Broj telefona mora biti u obliku yyy/1234567!";
            }

            if (string.IsNullOrEmpty(p.email))
            {
                return "Morate unijeti neke podatke za email profesora";
            }
            else
            {
                Match match = _RegexEmail.Match(p.email);
                if (!match.Success)
                    return "Email mora da bude u sledecem formatu prezime.ime@uns.ac.rs!";
            }

            if (string.IsNullOrEmpty(p.adresak))
            {
                return "Morate unijeti neke podatke za  adresu kancelarije profesora!";
            }
            

            if (string.IsNullOrEmpty(p.broj_licne))
            {
                return "Morate unijeti neke podatke za broj licne karte profesora";
            }
            

            if (string.IsNullOrEmpty(p.zvanje))
            {
                return "Morate unijeti neke podatke za zvanje profesora";
            }

            if (p.godine_staza == -1)
            {
                return "Morate unijeti neke podatke za godine staza profesora!";
            }
            else
            {
                Match match = _GodinaRegex.Match(p.godine_staza.ToString());
                if (!match.Success)
                    return "Godine staza profesora mogu imate 1 ili 2 cifre samo!";
            }

            if (p.id_katedre == -1)
            {
                return "Morate unijeti neke podatke za katedru profesora!";
            }

            return null;

        }


    }
}
