using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
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
    /// Interaction logic for PoloziProzor.xaml
    /// </summary>
    public partial class PoloziProzor : Window, INotifyPropertyChanged
    {
        public Predmet Predmet1;
        public ObservableCollection<OcenaNaIspitu> Pr;
        public ObservableCollection<Predmet> P;
        public IspitController _ispitcont;
        public Student st;
        public UpdateStudent uss;
        public PoloziProzor(Predmet p, ObservableCollection<OcenaNaIspitu> PredmetiPol, ObservableCollection<Predmet> PredmetiNep,IspitController ispitcont,Student s,UpdateStudent us)
        {
            InitializeComponent();
            _ispitcont = ispitcont;
            st = s;

            

            Pr= PredmetiPol;
            P= PredmetiNep;
            Predmet1 = p;
            Text1.Content = p.sifra_predmeta;
            Text2.Content = p.naziv_predmeta;
            uss = us;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Click_potvrdi(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(ComboBoxOcjena.Text))
            {
                    MessageBox.Show("Morate unijeti neke podatke za ocjenu!");
                    return;
            }
            if (string.IsNullOrEmpty(DatumTextBox.Text))
            {
                    MessageBox.Show("Morate unijeti neke podatke za datum polaganja ispita!");
                    return;
            }

            if (Predmet1 != null)
            {
                OcenaNaIspitu ispit=new OcenaNaIspitu();
                foreach (OcenaNaIspitu ispit2 in _ispitcont.GetAllIspit())
                {
                    if (ispit2.idIspita == 0 && ispit2.sifraPredmeta == Predmet1.sifra_predmeta && st.Id == ispit2.idStudenta)
                    {
                        _ispitcont.Delete(ispit2);
                        ispit = ispit2;
                        break;
                    }
                }
                String str = ComboBoxOcjena.Text;
                ispit.ocjena = int.Parse(str);

                ispit.datum = DateTime.Parse(DatumTextBox.Text);
                ispit.idIspita = 1;
                _ispitcont.Create(ispit);
                Pr.Add(ispit);
                P.Remove(Predmet1);

                uss.Update();
                this.Close();
            }
            else
            {
                MessageBox.Show("Morate izabrati predmet za polaganje");
            }
        }

        private void Click_odustani(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
