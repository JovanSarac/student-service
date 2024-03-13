using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for DodajPredmet.xaml
    /// </summary>
    
    public partial class DodajPredmet : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Predmet> predmetizadod { get;  }
        public Predmet SelectedPr { get; set; }
        private PredmetController _cont;
        public Profesor p;
        ObservableCollection<Predmet> listapredmeta;
        public MainWindow ww;
        public DodajPredmet(PredmetController pr,Profesor pp,ObservableCollection<Predmet> l,MainWindow w)
        {
            ww = w;
            InitializeComponent();
            DataContext = this;

            

            listapredmeta = l;
            p = pp;
            predmetizadod = new ObservableCollection<Predmet>();
            _cont = pr;
            foreach(var predmet in _cont.GetAllPredmet())
            {
                if(predmet.predmetni_profesor!=p.ime + " " + p.prezime)
                {
                    predmetizadod.Add(predmet);
                   
                }

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Click_DodajPotvrda(object sender, RoutedEventArgs e)
        {
            if (SelectedPr != null)
            {
                
                _cont.Delete(SelectedPr);
                SelectedPr.predmetni_profesor = p.ime + " " + p.prezime;
                _cont.Create(SelectedPr);
                listapredmeta.Add(SelectedPr);
                ww.Update();
                this.Close();
                

            }
            else
            {
                MessageBox.Show("Morate izabrati predmet za dodavanje");
            }

        }

        private void Click_DodajOdustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
