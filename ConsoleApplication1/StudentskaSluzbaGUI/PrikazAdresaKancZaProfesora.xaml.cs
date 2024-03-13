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
    /// Interaction logic for PrikazAdresaKancZaProfesora.xaml
    /// </summary>
    public partial class PrikazAdresaKancZaProfesora : Window
    {

        public ObservableCollection<Adresa> AdresaList { get; set; }
        public Adresa SelectedAdresa { get; set; }
        public AddProfesor adprof;
        public AdresaController _adresacontroller;

        public PrikazAdresaKancZaProfesora(AddProfesor adpr)
        {
            InitializeComponent();
            DataContext = this;
            _adresacontroller = new AdresaController();
            adprof = adpr;
            

            AdresaList = new ObservableCollection<Adresa>(_adresacontroller.GetAllAdrese());
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajAdresuKanc_Click(object sender, RoutedEventArgs e)
        {        
             adprof.TextIdKanc.Text = SelectedAdresa.id_adr.ToString();
             this.Close();
            
        }

    }
}
