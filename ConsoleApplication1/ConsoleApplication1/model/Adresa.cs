using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Manager.Serialization;
using System.ComponentModel;

namespace ConsoleApplication1.model
{
    public class Adresa : Serializable, INotifyPropertyChanged
    {
        public int id_adr { get; set; }
        public int Id_adrese
        {
            get { return id_adr; }
            set { id_adr = value; OnPropertyChanged("Id_adrese"); }
        }
        public string ulica { get; set; }
        public string Ulica
        {
            get { return ulica; }
            set { ulica = value; OnPropertyChanged("Ulica"); }
        }
        public int broj { get; set; }
        public int Broj
        {
            get { return broj; }
            set { broj = value; OnPropertyChanged("Broj"); }
        }
        public string grad { get; set; }
        public string Grad
        {
            get { return grad; }
            set { grad = value; OnPropertyChanged("Grad"); }
        }
        public string drzava { get; set; }
        public string Drzava
        {
            get { return drzava; }
            set { drzava = value; OnPropertyChanged("Drzava"); }
        }

        public Adresa(int id_adr, string ulica, int broj, string grad, string drzava)
        {
            this.id_adr = id_adr;
            this.ulica = ulica;
            this.broj = broj;
            this.grad = grad;
            this.drzava = drzava;
        }

        public Adresa() { }

        public override string ToString()
        {
            return String.Format("|Ulica: {0} \n|Broj : {1} \n|Grad: {2} \n|Drzava: {3} \n",ulica,broj,grad,drzava);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                id_adr.ToString(),
                ulica,
                broj.ToString(),
                grad,
                drzava        
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            id_adr =int.Parse(values[0]);
            ulica = values[1];
            broj = int.Parse(values[2]);
            grad = values[3];
            drzava = values[4];

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
