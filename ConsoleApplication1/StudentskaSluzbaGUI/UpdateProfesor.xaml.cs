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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using StudentskaSluzbaGUI.Controller;
using System.Collections.ObjectModel;
using ConsoleApplication1.model;

namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for UpdateProfesor.xaml
    /// </summary>
    public partial class UpdateProfesor : Window, INotifyPropertyChanged
    {
        private ProfesorController _profesorcontroller;
        public Profesor profesor;
        public ObservableCollection<Predmet> predmetiii { get;  }
        public PredmetController _predmetcontroller;
        public Predmet SelectedPredmetProf { get; set; }
        public MainWindow ww;
        public UpdateProfesor(ProfesorController controller,PredmetController prcontroller,Profesor p,MainWindow w)
        {
            InitializeComponent();
            DataContext = this;
            profesor = p;
            ww = w;

            


            TextIme.Text = p.ime;
            TextPrz.Text = p.prezime;
            TextDatRodj.Text = p.datum_rodjenja.ToString();
            TextAdrSt.Text = p.adresap;
            TextBrTel.Text = p.kontakt_telefon;
            TextEmail.Text = p.email;
            TextIdKanc.Text = p.adresak;
            TextBrLic.Text = p.broj_licne;
            TextZvanje.Text = p.zvanje;
            TextGodStaz.Text = p.godine_staza.ToString();
            TextIdKatedre.Text = p.id_katedre.ToString();
            
            _predmetcontroller = prcontroller;
            
            predmetiii=new ObservableCollection<Predmet>();
            
            foreach(var predmet in _predmetcontroller.GetAllPredmet())
            {
                
                if(p.ime + " " + p.prezime == predmet.predmetni_profesor)
                {
                    predmetiii.Add(predmet);
                    
                }

            }

            _profesorcontroller = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseUpdateProfesor_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateProfesor_Click(object sender, RoutedEventArgs e)
        {
            
            profesor.ime = TextIme.Text;
            profesor.prezime = TextPrz.Text;

            String datrdj = TextDatRodj.Text;
            DateTime datumRodj = DateTime.Parse(datrdj);
            profesor.datum_rodjenja = datumRodj;

            String adrst = TextAdrSt.Text;
           
            profesor.adresap = adrst;

            profesor.kontakt_telefon = TextBrTel.Text;
            profesor.email = TextEmail.Text;

            String idkan = TextIdKanc.Text;
            
            profesor.adresak = idkan;
            
            profesor.broj_licne = TextBrLic.Text;
            profesor.zvanje = TextZvanje.Text;

            String godst = TextGodStaz.Text;
            int godineStaza = string.IsNullOrEmpty(godst) ? -1 : int.Parse(godst);
            profesor.godine_staza = godineStaza;

            String idkat = TextIdKatedre.Text;
            int idKatedra = string.IsNullOrEmpty(idkat) ? -1 : int.Parse(idkat);
            profesor.id_katedre = idKatedra;

            if (profesor.IsValid(profesor) == null)
            {
                _profesorcontroller.Update(profesor);
                Close();
            }
            else
            {
                string s = profesor.IsValid(profesor);
                MessageBox.Show(s);
            }
            
        }
        private void Click_UkloniPredmet(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmetProf != null)
            {
                MessageBoxResult result = ConfirmPredmetDeletion3();
                if (result == MessageBoxResult.Yes)
                {
                    _predmetcontroller.Delete(SelectedPredmetProf);
                    SelectedPredmetProf.predmetni_profesor = "";
                    _predmetcontroller.Create(SelectedPredmetProf);

                    predmetiii.Remove(SelectedPredmetProf);
                    ww.Update();
                }

            }
            else
            {
                MessageBox.Show("Morate izabrati predmet za uklanjanje");
            }

        }
        private void Click_DodajPredmet(object sender, RoutedEventArgs e)
        {
            
                var otvori = new DodajPredmet(_predmetcontroller,profesor,predmetiii,ww);
                otvori.Show();


            

        }
        private MessageBoxResult ConfirmPredmetDeletion3()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrisete predmet\n{SelectedPredmetProf}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

    }
}
