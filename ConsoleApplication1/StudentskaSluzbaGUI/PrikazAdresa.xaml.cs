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
    /// Interaction logic for PrikazAdresa.xaml
    /// </summary>
    public partial class PrikazAdresa : Window
    {
        public ObservableCollection<Adresa> AdresaList { get; set; }
        public Adresa SelectedAdresa { get; set; }
        public AddStudent ad;
        public AddProfesor adprof;
        public AdresaController _adresacontroller;

        public StudentController _studentcontroller;
        public List<Student> studenti;

        int pomocnastudent = 0;    //pomocne promjenljive da znam u kom sam prozoru
        int pomocnaprofesor = 0;
        
        public PrikazAdresa(AddProfesor adp)
        {
            InitializeComponent();
            DataContext = this;
            _adresacontroller = new AdresaController();
            adprof = adp;
            pomocnaprofesor++;

            AdresaList = new ObservableCollection<Adresa>(_adresacontroller.GetAllAdrese());
        }

        public PrikazAdresa(AddStudent ads)
        {
            InitializeComponent();
            DataContext = this;
            _adresacontroller = new AdresaController();
            ad = ads;
            pomocnastudent++;
           
            List<Adresa> trazene_adrese = new List<Adresa>();

            //studenti = _studentcontroller.GetAllStudents();

            
            foreach(Adresa a in _adresacontroller.GetAllAdrese())
            {
                
                int broj = 0;
                /*
                foreach(Student s in _studentcontroller.GetAllStudents()) 
                {
                    
                    if(a.id_adr.ToString() == s.adresas)
                    {
                        broj++;
                    }
                }*/
                
                if(broj == 0)
                {
                    trazene_adrese.Add(a);
                }
                
            }

            AdresaList = new ObservableCollection<Adresa>(trazene_adrese);
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajAdresuStudentu_Click(object sender, RoutedEventArgs e)
        {
            if (pomocnastudent != 0)
            {
                ad.TextAdrSt.Text = SelectedAdresa.id_adr.ToString();
                this.Close();
            }else if (pomocnaprofesor != 0)
            {
                adprof.TextAdrSt.Text = SelectedAdresa.id_adr.ToString();
                this.Close();
            }
        }
    }
}
