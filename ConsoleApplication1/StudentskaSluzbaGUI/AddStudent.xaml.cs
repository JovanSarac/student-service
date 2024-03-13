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
using ConsoleApplication1.Manager;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using StudentskaSluzbaGUI.Controller;


namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddStudent : Window , INotifyPropertyChanged
    {
        private StudentController _studentcontroller;
        public Student Student { get; set; }

        public AddStudent(StudentController controller)
        {
            InitializeComponent();
            DataContext = this;
            Student = new Student();

            _studentcontroller = controller;

        }

        private void CreateStudent_Click(object sender, RoutedEventArgs e)
        {
            
            int id =  0 ; 
            String ime = TextIme.Text;
            String prezime = TextPrezime.Text;
            String datrdj = Datum.Text;
            DateTime datumrodj = default(DateTime);
            if (!string.IsNullOrEmpty(datrdj))
            {
                datumrodj = DateTime.Parse(datrdj);

            }
            else
            {
                MessageBox.Show("Morate unijeti neke podatke za datum rodjenja!");
                return;
            }

            String adrst = TextAdrSt.Text;

            
            String brtel = TextBrtel.Text;
            String email = TextEmail.Text;
            String brindx = TextBri.Text;
            String gu = TextGodUpis.Text;
            int godupis = string.IsNullOrEmpty(gu) ? 0 : int.Parse(gu);
            String nacfn = ComboNacinFin.Text;
            String tgu = ComboTrGodStud.Text;
            int trenutnagod = string.IsNullOrEmpty(tgu) ? 0 : int.Parse(tgu);
            

            if (nacfn == "B")
            {               
                Status nacin_fin = Status.B;
                Student = new Student(id, ime, prezime, datumrodj, adrst, brtel, email, brindx, godupis, trenutnagod, nacin_fin);
             
            }
            else if (nacfn == "S")
            {
                Status nacin_fin =  Status.S;
                Student = new Student(id, ime, prezime, datumrodj, adrst, brtel, email, brindx, godupis, trenutnagod, nacin_fin);

            }else
            {
                MessageBox.Show("Morate unijeti neku vrijednost za nacin finansiranja!");
            }

             if ( nacfn == "S" || nacfn == "B" )   //znaci da je student kreiran
             {               
                if (Student.IsValid(Student) == null)
                {
                    _studentcontroller.Create(Student);
                    Close();
                }
                else
                {
                    string s = Student.IsValid(Student);
                    MessageBox.Show(s);
                }
            }
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DodajAdresu_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new PrikazAdresa(this);
            otvoriProzor.Show();

        }
    }
}
