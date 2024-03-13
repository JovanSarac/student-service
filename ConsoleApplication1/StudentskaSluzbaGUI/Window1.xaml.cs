using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Controller;
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

namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    

    public partial class Window1 : Window
    {
        
        public ProfesorController _profcont;
        public KatedreController _katcont;

        public Window1()
        {
            InitializeComponent();
            DataContext = this;
            _katcont = new KatedreController();
            _profcont = new ProfesorController();

        }

        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Potvrdi(object sender, RoutedEventArgs e)
        {
            Katedra k=new Katedra();

            //validacija da polja ne smiju biti prazna prilikom promjene sefa katedre
            if (string.IsNullOrEmpty(SifraKatedre.Text))
            {
                MessageBox.Show("Morate unijeti neke podatke za sifru katedre!");
                return;
            }

            if (string.IsNullOrEmpty(IdProfesora.Text))
            {
                MessageBox.Show("Morate unijeti neke podatke za Id profesora!");
                return;
            }

            int a = 0;
            int b = 0;
            foreach (var katedra in _katcont.GetAllKatedra())
            {
                if(katedra.sifra_katedre == int.Parse(SifraKatedre.Text))
                {
                    a++;
                    break;
                }
            }
            foreach(var profesor in _profcont.GetAllProfesor())
            {
                if (profesor.Id == int.Parse(IdProfesora.Text))
                {
                    b++;
                    break;
                }

            }

            if (a == 1 && b == 1)
            {


                foreach (var katedra in _katcont.GetAllKatedra())
                {
                    if (katedra.sifra_katedre == int.Parse(SifraKatedre.Text))
                    {
                        k = katedra;
                        break;
                    }

                }
                _katcont.Delete(k);
                k.idSefaKatedra = int.Parse(IdProfesora.Text);
                _katcont.Create(k);
            }
            else
            {
                MessageBox.Show("Id katedre ili prof ne postoji");

            }
            this.Close();
        }

        private void Dodaj_sefa_Katedre_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new PrikazProfzaSefaKat(this);
            otvoriProzor.Show();

        }

        private void Dodaj_Sifrukat_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new PrikazKatedri(this);
            otvoriProzor.Show();
        }
    }
}
