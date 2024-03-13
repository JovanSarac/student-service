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
    public partial class AddProfesor : Window, INotifyPropertyChanged
    {

        ProfesorController _profesorcontroller;
        public Profesor Profesor { get; set; }
        public Window1 w1;

        public AddProfesor(ProfesorController controller)
        {
            InitializeComponent();
            DataContext = this;
            Profesor = new Profesor();

            _profesorcontroller = controller;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateProfesor_Click(object sender, RoutedEventArgs e)
        {
            
            int id = 0;
            String ime = TextIme.Text;
            String prezime = TextPrz.Text;
            String datrdj = TextDatRodj.Text;           
            DateTime datumRodj = default(DateTime);
            if (!string.IsNullOrEmpty(datrdj))
            {
                datumRodj = DateTime.Parse(datrdj);

            }
            else
            {
                MessageBox.Show("Morate unijeti neke podatke za datum rodjenja!");
                return;
            }
            String adrst = TextAdrSt.Text;
            
            String brtel = TextBrTel.Text;
            String email = TextEmail.Text;
            String idkan = TextIdKanc.Text;
            
            String brlic = TextBrLic.Text;
            String zvanje = TextZvanje.Text;
            String godst = TextGodStaz.Text;
            int godineStaza = string.IsNullOrEmpty(godst) ? -1 : int.Parse(godst);
            String idkat = TextIdKatedre.Text;
            int idKatedra = string.IsNullOrEmpty(idkat) ? -1 : int.Parse(idkat);

            Profesor = new Profesor(id, ime, prezime, datumRodj, adrst, brtel, email, idkan, brlic, zvanje, godineStaza, idKatedra);

            if (Profesor.IsValid(Profesor) == null)
            {
                _profesorcontroller.Create(Profesor);
                Close();
            }
            else
            {
                string s = Profesor.IsValid(Profesor);
                MessageBox.Show(s);
            }

            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Izaberi_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new PrikazKatedriZaProfesora(this);
            otvoriProzor.Show();

        }

        private void DodajAdrStProf_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new PrikazAdresa(this);
            otvoriProzor.Show();

        }

        private void DodatAdrKancProf_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new PrikazAdresaKancZaProfesora(this);
            otvoriProzor.Show();
        }
    }
}
