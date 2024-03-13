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
using System.Collections.ObjectModel;

namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window, INotifyPropertyChanged
    {
        private StudentController _studentcontroller;
        private IspitController _ispitcont;
        public Student St { get; set; }

        private PredmetController _predmetcont;
        public ObservableCollection<Predmet> Predmeti { get; }
        public ObservableCollection<Predmet> PredmetiNep { get; }
        public ObservableCollection<OcenaNaIspitu> PredmetiPol { get; }

        
        public Predmet SelectedPredmet { get; set; }

        public OcenaNaIspitu SelectedPredmetPol { get; set; }
        public UpdateStudent(StudentController controller,Student s)
        {
            InitializeComponent();
            DataContext = this;
            St = s;
            TextIme.Text = s.Ime;
            TextPrezime.Text = s.Prezime;
            TextDatrodj.Text = s.datum_rodjenja.ToString();
            TextAdrSt.Text = s.adresas;
            TextBrtel.Text = s.telefon;
            TextEmail.Text = s.email;
            TextBri.Text = s.broj_indeksa;
            TextGodUpis.Text = s.godina_upisa.ToString();
            ComboTrGodStud.Text = s.trenutna_godina_studija.ToString();
            ComboNacinFin.Text = s.nacin_finansiranja.ToString();

           _predmetcont = new PredmetController();
           _ispitcont = new IspitController();

           PredmetiNep = new ObservableCollection<Predmet>();
           PredmetiPol = new ObservableCollection<OcenaNaIspitu>();
            

            foreach(var ispit in _ispitcont.GetAllIspit())
            {
                if(ispit.idStudenta==St.Id && ispit.idIspita == 0)
                {
                    foreach(var predmet in _predmetcont.GetAllPredmet())
                    {
                        if (predmet.sifra_predmeta == ispit.sifraPredmeta) PredmetiNep.Add(predmet);
                    }  
                }
            }
            int sumaESPB = 0;
            int sumocjena = 0;
            int n = 0;
            foreach (var ispit in _ispitcont.GetAllIspit())
            {
                if (ispit.idStudenta == St.Id && ispit.idIspita == 1)
                {
                    PredmetiPol.Add(ispit);
                    
                           
                            sumaESPB += ispit.broj_ESPB;
                            sumocjena += ispit.ocjena;
                            n++;
                       
                }
            }
            if(n!=0)
                PrOcjena.Content =Math.Round( (double)sumocjena / n,3);
            else
                PrOcjena.Content = 0;
            
            UkupnoESPB.Content = sumaESPB;
            _studentcontroller = controller;
        }

        public void Update()
        {
            int sumaESPB = 0;
            int sumocjena = 0;
            int n = 0;
            foreach (var ispit in _ispitcont.GetAllIspit())
            {
                if (ispit.idStudenta == St.Id && ispit.idIspita == 1)
                {
                    foreach (var predmet in _predmetcont.GetAllPredmet())
                    {
                        if (predmet.sifra_predmeta == ispit.sifraPredmeta)
                        {
                            
                            sumaESPB += predmet.broj_ESPB;
                            sumocjena += ispit.ocjena;
                            n++;
                        }
                    }
                }
            }
            if (n != 0)
                PrOcjena.Content = Math.Round((double)sumocjena / n, 3);
            else
                PrOcjena.Content = 0;

            St.prosecna_ocena = double.Parse(PrOcjena.Content.ToString());
            _studentcontroller.Update(St);

            UkupnoESPB.Content = sumaESPB;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CloseUpdate_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            St.ime = TextIme.Text;
            St.prezime = TextPrezime.Text;
            String datrdj = TextDatrodj.Text;
            DateTime datumrodj = DateTime.Parse(datrdj);
            St.datum_rodjenja = datumrodj;

            String adrst = TextAdrSt.Text;
           
            St.adresas = adrst;

            St.telefon = TextBrtel.Text;
            St.email = TextEmail.Text;
            St.broj_indeksa  = TextBri.Text;

            String gu = TextGodUpis.Text;
            int godupis = string.IsNullOrEmpty(gu) ? 0 : int.Parse(gu);
            St.godina_upisa = godupis;

            
            String tgu = ComboTrGodStud.Text;
            int trenutnagod = int.Parse(tgu);
            St.trenutna_godina_studija = trenutnagod;

            String nacfn = ComboNacinFin.Text;
            

            if (nacfn == "B")
            {
                Status nacin_fin = Status.B;
                St.nacin_finansiranja = nacin_fin;
               
            }
            else if (nacfn == "S")
            {
                Status nacin_fin = Status.S;
                St.nacin_finansiranja = nacin_fin;
            }


            if (St.IsValid(St) == null)
            {
                _studentcontroller.Update(St);
                Close();
            }
            else
            {
                string s = St.IsValid(St);
                MessageBox.Show(s);
            }
        }

        private void OtvoriOdabir(object sender, RoutedEventArgs e)
        {
            var otvori = new IzaberiPredmet(_predmetcont,_ispitcont,PredmetiNep,PredmetiPol,St);
            otvori.Show();
        }

        private void Click_Obrisi(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet != null)
            {
                MessageBoxResult result = ConfirmPredmetDeletion2();
                if (result == MessageBoxResult.Yes)
                {
                    
                    
                    foreach(OcenaNaIspitu ispit2 in _ispitcont.GetAllIspit())
                    {
                        if(ispit2.idIspita==0 && ispit2.sifraPredmeta==SelectedPredmet.sifra_predmeta && St.Id == ispit2.idStudenta)
                        {
                            _ispitcont.Delete(ispit2);
                            break;
                        }
                    }
                    PredmetiNep.Remove(SelectedPredmet);

                    
                    
                    
                }
                

            }
            else
            {
                MessageBox.Show("Morate izabrati predmet za brisanje");
            }
        }

        private void Click_Polozi(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet != null)
            {
                var otvori = new PoloziProzor(SelectedPredmet,PredmetiPol,PredmetiNep,_ispitcont,St,this);
                otvori.Show();

            }
            else
            {
                MessageBox.Show("Morate izabrati predmet za polaganje");
            }
        }

        private void Click_Ponisti(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmetPol != null)
            {

                MessageBoxResult result = ConfirmPredmetDeletion();
                if (result == MessageBoxResult.Yes)
                {
                    OcenaNaIspitu ispit = new OcenaNaIspitu();
                    foreach (OcenaNaIspitu ispit2 in _ispitcont.GetAllIspit())
                    {
                        if (ispit2.idIspita == 1 && ispit2.sifraPredmeta == SelectedPredmetPol.sifraPredmeta && St.Id == ispit2.idStudenta)
                        {
                            _ispitcont.Delete(ispit2);
                            ispit = ispit2;
                            break;
                        }
                    }
                    Predmet predmet= new Predmet();
                    foreach(var predmet1 in _predmetcont.GetAllPredmet())
                    {
                        if (SelectedPredmetPol.sifraPredmeta == predmet1.sifra_predmeta)
                        {
                            predmet=predmet1;
                        }

                    }

                    ispit.ocjena = 0;
                    ispit.datum = DateTime.MinValue;
                    ispit.idIspita = 0;
                    _ispitcont.Create(ispit);
                    PredmetiNep.Add(predmet);
                    PredmetiPol.Remove(SelectedPredmetPol);
                    this.Update();
                }
                
                

            }
            else
            {
                MessageBox.Show("Morate izabrati ispit za ponistavanje");
            }
        }

        private MessageBoxResult ConfirmPredmetDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da ponistite ispit\n{SelectedPredmetPol}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmPredmetDeletion2()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrisete predmet\n{SelectedPredmet}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }
    }
}
