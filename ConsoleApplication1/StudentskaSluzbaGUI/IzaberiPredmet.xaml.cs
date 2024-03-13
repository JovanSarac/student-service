using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for IzaberiPredmet.xaml
    /// </summary>
    public partial class IzaberiPredmet : Window
    {
        public Student St { get; set; }

        private IspitController _ispitcontroller;
        public ObservableCollection<Predmet> Predmeti { get; }
        public ObservableCollection<Predmet> P { get; }

        public ObservableCollection<OcenaNaIspitu> P2 { get; }
        public Predmet SelectedPredmet { get; set; }
        public IzaberiPredmet(PredmetController controller,IspitController ispitcontroller, ObservableCollection<Predmet> PredmetiNep, ObservableCollection<OcenaNaIspitu> PredmetiPol, Student s)
        {
            InitializeComponent();
            DataContext = this;

            _ispitcontroller = ispitcontroller;
            

            St = s;
            P = PredmetiNep;
            P2 = PredmetiPol;
            Predmeti = new ObservableCollection<Predmet>(controller.GetSomePredmet(s.trenutna_godina_studija));
            foreach(var predmet in PredmetiNep)
            {
                Predmeti.Remove(predmet);

            }

            foreach(var ispit in PredmetiPol)
            {
                foreach(var predmet in Predmeti)
                {
                    if (ispit.sifraPredmeta == predmet.sifra_predmeta)
                    {
                        Predmeti.Remove(predmet);
                        break;
                    }

                }


            }

/*
            foreach (var predmet in PredmetiPol)
            {
                Predmeti.Remove(predmet);

            }*/
        }

        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {      
                if (SelectedPredmet != null )
                {
                
                P.Add(SelectedPredmet);

                OcenaNaIspitu ispit=new OcenaNaIspitu();
                ispit.idIspita = 0;
                ispit.sifraPredmeta = SelectedPredmet.sifra_predmeta;
                ispit.idStudenta = St.Id;
                ispit.ocjena = 0;
                ispit.datum = DateTime.MinValue;


                ispit.naziv_predmeta = SelectedPredmet.naziv_predmeta;
                ispit.broj_ESPB=SelectedPredmet.broj_ESPB;

                _ispitcontroller.Create(ispit);

                this.Close();
                }
                else
                {
                    MessageBox.Show("Morate izabrati predmet za dodavanje");
                }     
        }

        


    }
}
