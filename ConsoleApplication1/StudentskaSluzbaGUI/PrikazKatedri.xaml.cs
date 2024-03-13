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
    /// Interaction logic for PrikazKatedri.xaml
    /// </summary>
    public partial class PrikazKatedri : Window
    {
        public ObservableCollection<Katedra> KatedreList { get; set; }
        public KatedreController _katedracont;
        public Katedra SelectedKatedra { get; set; }
        public Window1 w1;

        public PrikazKatedri(Window1 w)
        {
            InitializeComponent();
            DataContext = this;
            _katedracont = new KatedreController();
            w1 = w;
            

            KatedreList = new ObservableCollection<Katedra>(_katedracont.GetAllKatedra());
        }


        private void Click_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PostaviKatedru_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedKatedra == null)
            {
                MessageBox.Show("Morate izabrati katedru!");
            }
            else
            {
                w1.SifraKatedre.Text = SelectedKatedra.sifra_katedre.ToString();
                this.Close();
            }
        }
    }
}
