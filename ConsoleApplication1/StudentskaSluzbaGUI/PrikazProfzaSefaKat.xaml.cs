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
    /// Interaction logic for PrikazProfzaSefaKat.xaml
    /// </summary>
    public partial class PrikazProfzaSefaKat : Window
    {
        public ObservableCollection<Profesor> Profesori { get; set; }
        public ProfesorController _profcont;
        public Profesor SelectedProf { get; set; }
        public Window1 w1;

        public PrikazProfzaSefaKat(Window1 w)
        {
            InitializeComponent();
            DataContext = this;
            _profcont = new ProfesorController();
            w1 = w;
            List<Profesor> profe = _profcont.GetAllProfesor();
            List<Profesor> posebni_profesori = new List<Profesor>();

            foreach(Profesor p in profe)
            {
                if((p.zvanje == "REDOVNI_PROFESOR" || p.zvanje == "VANREDNI_PROFESOR") && p.godine_staza >= 5)
                {
                    posebni_profesori.Add(p);
                }
            }
            Profesori = new ObservableCollection<Profesor>(posebni_profesori);

        }

        private void Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Postavi_Sefakat_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedProf == null)
            {
                MessageBox.Show("Morate izabrati profesora!");
            }else
            {
                w1.IdProfesora.Text = SelectedProf.Id.ToString();
                this.Close();
            }
        }
    }
}
