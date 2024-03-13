using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ConsoleApplication1.model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentskaSluzbaGUI.Controller;

namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for AddPredmet.xaml
    /// </summary>
    public partial class AddPredmet : Window, INotifyPropertyChanged
    {
        PredmetController _controllerpredmet;
        public Predmet Predmet { get; set; }

        public AddPredmet(PredmetController controller)
        {
            InitializeComponent();
            DataContext = this;
            Predmet = new Predmet();
            _controllerpredmet = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Predmet GetPredmetById(string id)
        {
            return _controllerpredmet.GetAllPredmet().Find(p => p.sifra_predmeta == id);
        }

        private void CreatePredmet_Click(object sender, RoutedEventArgs e)
        {
            String sifrapredmeta = TextSifraPred.Text;
            if (sifrapredmeta == "")
            {
                MessageBox.Show("Morate unijeti neke podatke za sifru predmeta!");
            }
            else
            {
                Predmet prpom = GetPredmetById(sifrapredmeta);
                if (prpom == null)
                {
                    String naziv = TextNaziv.Text;


                    String godIz = ComboTrGodIzvodjenja.Text;
                    int godinaIzvodjenja = string.IsNullOrEmpty(godIz) ? -1 : int.Parse(godIz);
                    String predmetniProfesor = "";
                    String bres = TextBrojESPB.Text;
                    int brojEspb = string.IsNullOrEmpty(bres) ? -1 : int.Parse(bres);

                    String semestar = ComboSemestar.Text;
                    Semestar sem;

                    if (semestar == "letnji")
                    {
                        sem = Semestar.letnji;
                        Predmet = new Predmet(sifrapredmeta, naziv, sem, godinaIzvodjenja, predmetniProfesor, brojEspb);
                    }
                    else if (semestar == "zimski")
                    {
                        sem = Semestar.zimski;
                        Predmet = new Predmet(sifrapredmeta, naziv, sem, godinaIzvodjenja, predmetniProfesor, brojEspb);
                    }
                    else
                    {
                        MessageBox.Show("Morate unijeti konkretan semestar(letnji,zimski)!");
                    }

                    if (semestar == "zimski" || semestar == "letnji") //znaci da je kreiran predmet
                    {
                        if (Predmet.IsValid(Predmet) == null)
                        {
                            _controllerpredmet.Create(Predmet);
                            Close();
                        }
                        else
                        {
                            string s = Predmet.IsValid(Predmet);
                            MessageBox.Show(s);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Postoji predmet vec sa tom sifrom. Morate promjeniti sifru predmeta!");
                }
            }

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
