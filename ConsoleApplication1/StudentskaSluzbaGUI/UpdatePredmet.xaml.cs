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
    /// Interaction logic for UpdatePredmet.xaml
    /// </summary>
    public partial class UpdatePredmet : Window, INotifyPropertyChanged
    {
        private PredmetController _predmetcontroller;
        public Predmet predmet;
        public UpdatePredmet(PredmetController controller, Predmet p)
        {
            InitializeComponent();
            DataContext = this;
            foreach(var pr in controller.GetAllPredmet())
            {
                if (pr.sifra_predmeta == p.sifra_predmeta)
                {
                    System.Console.WriteLine(pr.predmetni_profesor);
                    p.predmetni_profesor = pr.predmetni_profesor;
                    break;
                }

            }

            predmet = p;
            TextNaziv.Text = p.naziv_predmeta;
            ComboSemestar.Text = p.semestar.ToString();
            ComboTrGodIzvodjenja.Text = p.godina_studija_ukojoj_se_predmet_izvodi.ToString();
            TextPredmetniProf.Content = p.predmetni_profesor;
            TextBrojESPB.Text = p.broj_ESPB.ToString();

            _predmetcontroller = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseUpdatePredmet_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdatePredmet_Click(object sender, RoutedEventArgs e)
        {
            
            predmet.naziv_predmeta = TextNaziv.Text;

            String godIz = ComboTrGodIzvodjenja.Text;
            int godinaIzvodjenja = int.Parse(godIz);
            predmet.godina_studija_ukojoj_se_predmet_izvodi = godinaIzvodjenja;

            predmet.predmetni_profesor = TextPredmetniProf.Content.ToString();
            
            String bres = TextBrojESPB.Text;
            int brojEspb = string.IsNullOrEmpty(bres) ? -1 : int.Parse(bres);
            predmet.broj_ESPB = brojEspb;

            String semestar = ComboSemestar.Text;
            Semestar sem;

            if (semestar == "letnji")
            {
                sem = Semestar.letnji;
                predmet.semestar = sem;
            }
            else if (semestar == "zimski")
            {
                sem = Semestar.zimski;
                predmet.semestar = sem;
            }

            if (predmet.IsValid(predmet) == null)
            {
                _predmetcontroller.Update(predmet);
                Close();
            }
            else
            {
                string s = predmet.IsValid(predmet);
                MessageBox.Show(s);
            }
            
        }
        private void Click_DodajProf(object sender, RoutedEventArgs e)
        {
            if (TextPredmetniProf.Content.ToString() == "")
            {

                
                var otvoriProzor = new DodajProfNaPredmet(_predmetcontroller,predmet,this);
                otvoriProzor.Show();


            }


        }
        private void Click_UkloniProf(object sender, RoutedEventArgs e)
        {
            /*if (predmet.predmetni_profesor != "")
            {
                
                TextPredmetniProf.Content = "";
                
                

            }*/
            if(TextPredmetniProf.Content.ToString() != "")
            {
                MessageBoxResult result = ConfirmProfDeletion();
                if(result==MessageBoxResult.Yes)
                    TextPredmetniProf.Content = "";
            }


        }
        private MessageBoxResult ConfirmProfDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrisete prof?\n";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

    }
}
