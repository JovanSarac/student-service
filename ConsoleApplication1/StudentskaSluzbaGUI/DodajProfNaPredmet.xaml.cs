using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for DodajProfNaPredmet.xaml
    /// </summary>
    /// 
    
    public partial class DodajProfNaPredmet : Window
    {
        public ObservableCollection<Profesor> Profesori { get; set; }
        public ProfesorController _profcont;
        public Profesor SelectedProf { get; set; }
        public PredmetController _predmetcontroller;
        public Predmet predmet;
        public UpdatePredmet upp;
        public DodajProfNaPredmet(PredmetController _cont,Predmet p,UpdatePredmet up)
        {
            InitializeComponent();
            DataContext = this;
            upp = up;
            _predmetcontroller = _cont;
            _profcont = new ProfesorController();
            Profesori= new ObservableCollection<Profesor>(_profcont.GetAllProfesor());
            predmet = p;
        }
        private void Click_pot(object sender, RoutedEventArgs e)
        {
            if (SelectedProf != null)
            {
                MessageBoxResult result = ConfirmProfDodavanje();
                if (result == MessageBoxResult.Yes)
                {
                    upp.TextPredmetniProf.Content = SelectedProf.ime + " " + SelectedProf.prezime;

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati profesora!");

            }

            
        }

        private void Click_odu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private MessageBoxResult ConfirmProfDodavanje()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da dodate profesora\n{SelectedProf}";
            string sCaption = "Porvrda dodavanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

    }
}
