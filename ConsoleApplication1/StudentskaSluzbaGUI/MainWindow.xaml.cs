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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApplication1.model;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Net;
using ConsoleApplication1.Manager;
using StudentskaSluzbaGUI.Observer;
using StudentskaSluzbaGUI.Controller;
using StudentskaSluzbaGUI.Storage;


namespace StudentskaSluzbaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , IObserver
    {
        private IspitController _ispitcontroller;
        public ObservableCollection<OcenaNaIspitu> IspitList { get; }

        private StudentController _studentcontroller;
        public ObservableCollection<Student> StudentList { get; }
        public Student SelectedStudent { get; set; }

        private ProfesorController _profesorcontroller;
        public ObservableCollection<Profesor> ProfesorList { get; }
        public Profesor SelectedProfesor { get; set; }

        private PredmetController _predmetcontroller;
        public ObservableCollection<Predmet> PredmetList { get; }
        public Predmet SelectedPredmet { get; set; }

        
        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = this;



            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            


            _studentcontroller = new StudentController();
            _studentcontroller.Subscribe(this);
            StudentList = new ObservableCollection<Student>(_studentcontroller.GetAllStudents());

            _profesorcontroller = new ProfesorController();
            _profesorcontroller.Subscribe(this);
            ProfesorList = new ObservableCollection<Profesor>(_profesorcontroller.GetAllProfesor());

            _predmetcontroller = new PredmetController();
            _predmetcontroller.Subscribe(this);
            PredmetList = new ObservableCollection<Predmet>(_predmetcontroller.GetAllPredmet());

            _ispitcontroller = new IspitController();
            _ispitcontroller.Subscribe(this);
            IspitList = new ObservableCollection<OcenaNaIspitu>(_ispitcontroller.GetAllIspit());



        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            dateBlock.Text = DateTime.Now.ToString();
        }

        

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {

            if (tabControl.SelectedIndex == 0)
            {
                if(SelectedStudent != null)
                {
                    MessageBoxResult result = ConfirmStudentDeletion();
                    if(result == MessageBoxResult.Yes)
                    {
                        _studentcontroller.Delete(SelectedStudent);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati studenta za brisanje");
                }
            }else if(tabControl.SelectedIndex == 1)
            {
                if(SelectedProfesor != null)
                {
                    MessageBoxResult result = ConfirmProfesorDeletion();
                    if(result == MessageBoxResult.Yes)
                    {
                        _profesorcontroller.Delete(SelectedProfesor);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati profesora za brisanje");
                }
            }
            else if(tabControl.SelectedIndex == 2)
            {
                if(SelectedPredmet != null)
                {
                    MessageBoxResult result = ConfirmPredmetDeletion();
                    if(result == MessageBoxResult.Yes)
                    {
                        _predmetcontroller.Delete(SelectedPredmet);
                    }
                }
                else
                {
                    MessageBox.Show("Morate izabrati predmet za brisanje");
                }
            }           
        }

        private MessageBoxResult ConfirmStudentDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete stuenta\n{SelectedStudent}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmProfesorDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete profesora\n{SelectedProfesor}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmPredmetDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete predmet\n{SelectedPredmet}";
            string sCaption = "Porvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(tabControl.SelectedIndex == 0)
            {
                var otvoriAddStudent = new AddStudent(_studentcontroller);
                otvoriAddStudent.Show();
            }else if(tabControl.SelectedIndex == 1)
            {
                var otvoriAddProfesor = new AddProfesor(_profesorcontroller);
                otvoriAddProfesor.Show();
            }else if(tabControl.SelectedIndex == 2)
            {
                var otvoriAddPredmet = new AddPredmet(_predmetcontroller);
                otvoriAddPredmet.Show();
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                if (SelectedStudent != null)
                {
                    string sMessageBoxText = $"Prikaz studenta\n{SelectedStudent}";
                    MessageBox.Show(sMessageBoxText);

                }
                else
                {
                    MessageBox.Show("Morate izabrati studenta za prikaz");
                }
            
            }
            else if(tabControl.SelectedIndex == 1)
            {
                if (SelectedProfesor != null)
                {
                    string sMessageBoxText = $"Prikaz profesora\n{SelectedProfesor}";
                    MessageBox.Show(sMessageBoxText);

                }
                else
                {
                    MessageBox.Show("Morate izabrati profesora za prikaz");
                }

            }
            else if (tabControl.SelectedIndex == 2)
            {
                if (SelectedPredmet != null)
                {
                    string sMessageBoxText = $"Prikaz predmeta\n{SelectedPredmet}";
                    MessageBox.Show(sMessageBoxText);

                }
                else
                {
                    MessageBox.Show("Morate izabrati predmet za prikaz");
                }

            }

        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if(tabControl.SelectedIndex == 0)
            {
                if(SelectedStudent != null)
                {
                    var otvoriUpdateStudent = new UpdateStudent(_studentcontroller,SelectedStudent);
                    otvoriUpdateStudent.Show();
                }
                else
                {
                    MessageBox.Show("Morate izabrati studenta kojeg zelite da izmjenite!");
                }
            }else if(tabControl.SelectedIndex == 1)
            {
                if(SelectedProfesor!= null)
                {
                    var otvoriUpdateProfesor = new UpdateProfesor(_profesorcontroller,_predmetcontroller, SelectedProfesor,this);
                    otvoriUpdateProfesor.Show();
                }else
                {
                    MessageBox.Show("Morate izabrati profesora kojeg zelite da izmjenite!");
                }
            }else if(tabControl.SelectedIndex == 2)
            {
                if(SelectedPredmet != null)
                {
                    var otvoriUpdatePredmet = new UpdatePredmet(_predmetcontroller, SelectedPredmet);
                    otvoriUpdatePredmet.Show();
                }
                else
                {
                    MessageBox.Show("Morate izabrati predmet koji zelite da izmjenite!");
                }
            }
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StudentStorage st = new StudentStorage();
            ProfesorStorage ps = new ProfesorStorage();
            PredmetStorage pt = new PredmetStorage();

            st.Save(_studentcontroller.GetAllStudents());
            ps.Save(_profesorcontroller.GetAllProfesor());
            pt.Save(_predmetcontroller.GetAllPredmet());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.N))
                Add_Click(sender, e);
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.D))
                Button_Click_Delete(sender, e);
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.C))
                CloseMenu_Click(sender, e);
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.S))
                Save_Click(sender, e);
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.E))
                Update_Click(sender, e);
            else if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.O))
                Open_Click(sender, e);
        }


        private void UpdateStudentsList()
        {
            StudentList.Clear();
            foreach (var student in _studentcontroller.GetAllStudents())
            {
                StudentList.Add(student);
            }
        }

        private void UpdateProfesorList()
        {
            ProfesorList.Clear();
            foreach (var profesor in _profesorcontroller.GetAllProfesor())
            {
                ProfesorList.Add(profesor);
            }
        }

        private void UpdatePredmetList()
        {
            PredmetList.Clear();
            foreach (var predmet in _predmetcontroller.GetAllPredmet())
            {
                
                PredmetList.Add(predmet);
            }
        }

        public void Update()
        {
            UpdateStudentsList();
            UpdateProfesorList();
            UpdatePredmetList();
        }

       

        private void UpdateText(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                textUpdateTab.Text = "Studenti";
            else if (tabControl.SelectedIndex == 1)
                textUpdateTab.Text = "Profesori";
            else if (tabControl.SelectedIndex == 2)
                textUpdateTab.Text = "Predmeti";
        }

        private void Click_SefKatedre(object sender, RoutedEventArgs e)
        {
            var otvoriKatedreDodaj = new Window1();
            otvoriKatedreDodaj.Show();


        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String pretraga = textPretraga.Text;

            if (tabControl.SelectedIndex == 0)
            {
                if (pretraga == "")
                {
                    MessageBox.Show("Morate unijeti neke podatke za pretragu studenta!");
                    StudentList.Clear();
                    foreach (var student in _studentcontroller.GetAllStudents())
                    {
                        StudentList.Add(student);
                    }
                }

                List<Student> studenti = _studentcontroller.GetAllStudents();
                List<Student> pretrazeni_studenti = new List<Student>();


                string[] vrednosti = pretraga.Split(',');

                int brpr = vrednosti.Length;
                
                if (brpr == 1)   // unijeta pretraga prezime
                {
                    foreach (Student s in studenti)
                    {
                        if ((s.prezime.ToLower()).Contains(vrednosti[0].ToLower()))
                        {
                            pretrazeni_studenti.Add(s);
                        }
                    }
                    StudentList.Clear();
                    foreach (var student in pretrazeni_studenti)
                    {
                        StudentList.Add(student);
                    }
                }else if(brpr == 2)   //unijeta pretraga prezime,ime
                {
                    foreach(Student s in studenti)
                    {
                        if ((s.prezime.ToLower()).Contains(vrednosti[0].ToLower()) &&
                                (s.ime.ToLower()).Contains(vrednosti[1].ToLower()))
                        {
                            pretrazeni_studenti.Add(s);
                        }
                    }

                    StudentList.Clear();
                    foreach (var student in pretrazeni_studenti)
                    {
                        StudentList.Add(student);
                    }

                }else if(brpr == 3)    //unijeta pretraga index,ime,prezime
                {
                    foreach (Student s in studenti)
                    {
                        if ((s.broj_indeksa.ToLower()).Contains(vrednosti[0].ToLower())&&
                            (s.prezime.ToLower()).Contains(vrednosti[2].ToLower()) &&
                                (s.ime.ToLower()).Contains(vrednosti[1].ToLower()))
                        {
                            pretrazeni_studenti.Add(s);
                        }
                    }

                    StudentList.Clear();
                    foreach (var student in pretrazeni_studenti)
                    {
                        StudentList.Add(student);
                    }

                    textPretraga.Text = vrednosti[2] + " " + vrednosti[1] + " " + vrednosti[0];
                }else     //unijeto previse podataka
                {
                    MessageBox.Show("Mozete unijeti maksimalno tri podatka za pretragu koji su odvojeni zarezima!");
                }
                


            } else if(tabControl.SelectedIndex == 1)
            {
                if (pretraga == "")
                {
                    MessageBox.Show("Morate unijeti neke podatke za pretragu profesora!");
                    ProfesorList.Clear();
                    foreach (var profesor in _profesorcontroller.GetAllProfesor())
                    {
                        ProfesorList.Add(profesor);
                    }
                }

                List<Profesor> profesori = _profesorcontroller.GetAllProfesor();
                List<Profesor> pretrazeni_profesori = new List<Profesor>();

                string[] vrednosti = pretraga.Split(',');

                int brpr = vrednosti.Length;

                if(brpr == 1)    //unijeta pretraga po prezimenu
                {
                    foreach (Profesor p in profesori)
                    {
                        if ((p.prezime.ToLower()).Contains(vrednosti[0].ToLower()))
                        {
                            pretrazeni_profesori.Add(p);
                        }
                    }
                    ProfesorList.Clear();
                    foreach (var profesor in pretrazeni_profesori)
                    {
                        ProfesorList.Add(profesor);
                    }
                } else if(brpr == 2)    //unijeta pretraga po prezime,ime
                {
                    foreach (Profesor p in profesori)
                    {
                        if ((p.prezime.ToLower()).Contains(vrednosti[0].ToLower())
                            && (p.ime.ToLower()).Contains(vrednosti[1].ToLower()))
                        {
                            pretrazeni_profesori.Add(p);
                        }
                    }
                    ProfesorList.Clear();
                    foreach (var profesor in pretrazeni_profesori)
                    {
                        ProfesorList.Add(profesor);
                    }
                }
                else
                {
                    MessageBox.Show("Mozete unijeti maksimalno dva podatka za pretragu koji su odvojeni zarezima!");
                }
            }
            else if (tabControl.SelectedIndex == 2)
            {
                if (pretraga == "")
                {
                    MessageBox.Show("Morate unijeti neke podatke za pretragu predmeta!");
                    PredmetList.Clear();
                    foreach (var predmet in _predmetcontroller.GetAllPredmet())
                    {
                        PredmetList.Add(predmet);
                    }
                }

                List<Predmet> predmeti = _predmetcontroller.GetAllPredmet();
                List<Predmet> pretrazeni_predmeti = new List<Predmet>();

                string[] vrednosti = pretraga.Split(',');

                int brpr = vrednosti.Length;

                if(brpr == 1)   //unijeta pretraga po delu naziva predmeta
                {
                    foreach (Predmet p in predmeti)
                    {
                        if ((p.naziv_predmeta.ToLower()).Contains(vrednosti[0].ToLower()))
                        {
                            pretrazeni_predmeti.Add(p);
                        }
                    }
                    PredmetList.Clear();
                    foreach (var predmet in pretrazeni_predmeti)
                    {
                        PredmetList.Add(predmet);
                    }
                }
                else if(brpr == 2)      //unijeta pretraga po dijelu naziva predmeta,dio sifre predmeta
                {
                    foreach (Predmet p in predmeti)
                    {
                        if ((p.naziv_predmeta.ToLower()).Contains(vrednosti[0].ToLower()) 
                             && (p.sifra_predmeta.ToLower()).Contains(vrednosti[1].ToLower()))
                        {
                            pretrazeni_predmeti.Add(p);
                        }
                    }
                    PredmetList.Clear();
                    foreach (var predmet in pretrazeni_predmeti)
                    {
                        PredmetList.Add(predmet);
                    }
                } 


            }


        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var otvoriProzor = new Biografija();
            otvoriProzor.Show();
        }
    }
}
