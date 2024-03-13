using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.model;
using ConsoleApplication1.Manager;



namespace ConsoleApplication1.Console
{
    class AllConsoleView: ConsoleView
    {
        private StudentManager manager_student;
        private ProfesorManager manager_profesor;
        private PredmetManager manager_predmet;
        private OcenaNaIspituManager manager_ispit;
        private KatedraManager manager_katedra;
        private AdresaManager manager_adresa;



        public AllConsoleView(StudentManager mans,ProfesorManager manp, PredmetManager manpr, OcenaNaIspituManager mani, KatedraManager mank, AdresaManager manager_adresa)
        {
            this.manager_student = mans;
            this.manager_profesor = manp;
            this.manager_predmet = manpr;
            this.manager_ispit = mani;
            this.manager_katedra = mank;
            this.manager_adresa = manager_adresa;
        }

        private void PrintStudents(List<Student> students)
        {
            System.Console.WriteLine("Studenti: ");
            foreach (Student s in students)
            {               
                    System.Console.WriteLine(s);

                if (s.adresa_studenta == null)
                {

                    System.Console.WriteLine("|Adresa nije dobro zadata ");
                }
                else
                {
                    System.Console.WriteLine("Adresa :");
                    System.Console.WriteLine(s.adresa_studenta);

                }

                    if (s.polozeniPredmeti.Count() == 0)
                {
                    System.Console.WriteLine("|Polozeni predmeti: Nema polozenih predmeta ");
                }
                else
                {
                    System.Console.WriteLine("|Polozeni predmeti: \n");
                    foreach (Predmet pr in s.polozeniPredmeti)
                    {
                        System.Console.WriteLine(pr);
                        //System.Console.WriteLine("");
                    }
                }          
                if (s.nepolozeniPredmeti.Count() == 0)
                {
                    System.Console.WriteLine("|Nepolozeni predmeti: nema nepolozenih predmeta!\n");
                }
                else
                {
                    System.Console.WriteLine("|Nepolozeni predmeti: \n");
                    foreach (Predmet pr in s.nepolozeniPredmeti)
                    {
                        System.Console.WriteLine(pr);
                        System.Console.WriteLine("");
                    }
                }
            }
        }

        private void PrintProfesors(List<Profesor> profesori)
        {
            System.Console.WriteLine("Profesori: ");
            foreach (Profesor p in profesori)
            {
                System.Console.WriteLine(p);
                

                if (p.adresa_profesora == null)
                {
                    System.Console.WriteLine("Adresa profesora nije dobro zadata ");

                }
                else
                {
                    System.Console.WriteLine("Adresa stanovanja :");
                    System.Console.WriteLine(p.adresa_profesora);
                }

                if (p.adresa_kancelarije == null)
                {
                    System.Console.WriteLine("Adresa kancelarije nije dobro zadata ");

                }
                else
                {
                    System.Console.WriteLine("Adresa kancelarije :");
                    System.Console.WriteLine(p.adresa_kancelarije);
                }
                System.Console.WriteLine("|Predmeti gdje predaje: \n");
                foreach(Predmet pr in p.predmeti_gdje_predaje)
                {
                    System.Console.WriteLine(pr);
                    System.Console.WriteLine("");
                }
                
            }
        }

        private void PrintPredmets(List<Predmet> predmeti)
        {
            System.Console.WriteLine("Predmeti: ");
            foreach (Predmet p in predmeti)
            {
                System.Console.WriteLine(p);
                if (p.studenti_koji_su_polozili.Count() == 0)
                {
                    System.Console.WriteLine("|Studenti koji su polozili predmet: Nema studenata koji su polozili predmet!\n");
                }
                else
                {
                    System.Console.WriteLine("|Studenti koji su polozili predmet: \n");
                    foreach (Student pr in p.studenti_koji_su_polozili)
                    {
                        System.Console.WriteLine(pr);
                        System.Console.WriteLine("");
                    }
                }
            }
        }

        private void PrintIspits(List<OcenaNaIspitu> ispiti)
        {
            System.Console.WriteLine("Ispiti: ");
            foreach (OcenaNaIspitu i in ispiti)
            {
                System.Console.WriteLine(i);
            }

        }


        private void PrintKatedre(List<Katedra> katedre)
        {
            System.Console.WriteLine("Katedre: ");
            foreach (Katedra k in katedre)
            {
                System.Console.WriteLine(k);
                if (k.sef_katedre == null)
                {
                    System.Console.WriteLine("Sef nije dobro zadat : \n");
                }
                else
                {
                    System.Console.WriteLine("Sef katedre je : \n");
                    System.Console.WriteLine(k.sef_katedre);
                }

                System.Console.WriteLine("\nProfesori koji su na katedri : \n");
                foreach(Profesor p in k.profesori_na_katedri)
                {
                    System.Console.WriteLine(p);
                    System.Console.WriteLine("");
                }

            }

        }

        private void PrintAdrese(List<Adresa> adrese)
        {
            System.Console.WriteLine("Adrese: ");
            foreach (Adresa a in adrese)
            {
                System.Console.WriteLine(a);
 
            }

        }

        private Student InputStudent()
        {
            Student student = new Student();

            System.Console.WriteLine("Unesi ime studenta: ");
            string ime = System.Console.ReadLine();
            student.ime = ime;

            System.Console.WriteLine("Unesi prezime studenta: ");
            string prezime = System.Console.ReadLine();
            student.prezime = prezime;

            System.Console.WriteLine("Unesi datum rodjenja studenta: ");
            DateTime dt = SafeInputDateTime();
            student.datum_rodjenja = dt;

            System.Console.WriteLine("Unesi adresu stanovanja id studenta: ");
            int ads = SafeInputInt();
            student.adresa_stanovanja_id = ads;

            System.Console.WriteLine("Unesi telefon studenta: ");
            string t = System.Console.ReadLine();
            student.telefon = t;

            System.Console.WriteLine("Unesi email studenta: ");
            string e = System.Console.ReadLine();
            student.email = e;

            System.Console.WriteLine("Unesi broj indeksa studenta: ");
            string bi = System.Console.ReadLine();
            student.broj_indeksa = bi;

            System.Console.WriteLine("Unesi godinu upisa studenta: ");
            int gu = SafeInputInt();
            student.godina_upisa = gu;

            System.Console.WriteLine("Unesi trenutnu godinu studija studenta: ");
            int tgu = SafeInputInt();
            student.trenutna_godina_studija = tgu;

            string nf;
            do
            {
                System.Console.WriteLine("Unesi nacin finansiranja studenta(B - budzet,S - samofinansiranje): ");
                nf = System.Console.ReadLine();
            } while (nf != "B" && nf != "S");
            

            if (nf == "B")
            {
                student.nacin_finansiranja = Status.B;
            }else if(nf == "S")
            {
                student.nacin_finansiranja = Status.S;
            }
            


            System.Console.WriteLine("Unesi prosecnu ocenu studenta: ");
            double po = SafeInputDouble();
            student.prosecna_ocena = po;

            return student;
        }


        private Profesor InputProfesor()
        {
            Profesor profesor = new Profesor();
            List<Katedra> katedre = manager_katedra.GetAllKatedre();

            System.Console.WriteLine("Unesi prezime profesora: ");
            string prezime = System.Console.ReadLine();
            profesor.prezime = prezime;

            System.Console.WriteLine("Unesi ime profesora: ");
            string ime = System.Console.ReadLine();
            profesor.ime = ime;

            System.Console.WriteLine("Unesi datum rodjenja profesora: ");
            DateTime dt = SafeInputDateTime();
            profesor.datum_rodjenja = dt;

            System.Console.WriteLine("Unesi adresu stanovanja id profesora: ");
            int ads = SafeInputInt();
            profesor.adresa_stanovanja_id = ads;

            System.Console.WriteLine("Unesi kontakt telefon profesora: ");
            string t = System.Console.ReadLine();
            profesor.kontakt_telefon = t;

            System.Console.WriteLine("Unesi email profesora: ");
            string e = System.Console.ReadLine();
            profesor.email = e;

            System.Console.WriteLine("Unesi adresu kancelarije id od profesora : ");
            int adk = SafeInputInt();
            profesor.adresa_kancelarije_id = adk;

            System.Console.WriteLine("Unesi broj licne karte profesora: ");
            string brl = System.Console.ReadLine();
            profesor.broj_licne = brl;

            System.Console.WriteLine("Unesi zvanje profesora : ");
            string zvanje = System.Console.ReadLine();
            profesor.zvanje = zvanje;


            System.Console.WriteLine("Unesi godine staza profesora: ");
            int god = SafeInputInt();
            profesor.godine_staza = god;

            int kat;
            do
            {
                System.Console.WriteLine("Unesi id katedre profesora: ");
                kat = SafeInputInt();
                
            } while (katedre.Find(k => k.sifra_katedre == kat) == null);
            profesor.id_katedre = kat;

            return profesor;

        }

        public Predmet InputPredmet()
        {
            Predmet predmet = new model.Predmet();
            List<Predmet> predmeti = manager_predmet.GetAllPredmets();
            
            string sifra;
            do
            {
                System.Console.WriteLine("Unesi sifru predmeta: ");
                sifra = System.Console.ReadLine();
            } while (predmeti.Find(t => t.sifra_predmeta == sifra)!=null);
            predmet.sifra_predmeta = sifra;


            System.Console.WriteLine("Unesi naziv predmeta: ");
            string naziv = System.Console.ReadLine();
            predmet.naziv_predmeta = naziv;

            string sm;
            do {
                System.Console.WriteLine("Unesi semestar(letnji ili zimski): ");
                sm = System.Console.ReadLine();
            } while (sm != "letnji" && sm != "zimski");

            if(sm == "letnji")
            {
                predmet.semestar = Semestar.letnji;
            }else
            {
                predmet.semestar = Semestar.zimski;
            }
            

            System.Console.WriteLine("Unesi godinu studija u kojoj se predmet izvodi: ");
            int god = SafeInputInt();
            predmet.godina_studija_ukojoj_se_predmet_izvodi = god;


            do
            {
                System.Console.WriteLine("Unesi ime predmetnog profesora : ");
                string ime = System.Console.ReadLine();
                System.Console.WriteLine("Unesi prezime predmetnog profesora : ");
                string prezime = System.Console.ReadLine();

                List<Profesor> profesori = manager_profesor.GetAllProfesors();
                
                foreach (Profesor p in profesori)
                {
                    if (p.ime == ime)
                    {
                        if (p.prezime == prezime)
                        {
                            predmet.predmetni_profesor = ime + " " + prezime;
                        }
                    }
                }
            } while (predmet.predmetni_profesor == null);

            System.Console.WriteLine("Unesi broj ESPB bodova predmeta: ");
            int bodovi = SafeInputInt();
            predmet.broj_ESPB = bodovi;


            return predmet;
        }

        public OcenaNaIspitu InputIspit()
        {
            OcenaNaIspitu ispit = new model.OcenaNaIspitu();
            
            do
            {
                System.Console.WriteLine("Unesi validan id studenta: ");
                ispit.idStudenta = SafeInputInt();
                
            } while ((manager_student.GetAllStudents()).Find(v => v.Id == ispit.idStudenta) == null);

            do
            {
                System.Console.WriteLine("Unesi validnu sifru predmeta: ");
                ispit.sifraPredmeta = System.Console.ReadLine();

            } while (manager_predmet.GetAllPredmets().Find(v => v.sifra_predmeta == ispit.sifraPredmeta.ToString()) == null);
            
            do
            {
                System.Console.WriteLine("Unesi ocjenu (6-10): ");
                ispit.ocjena = SafeInputInt();

            } while (ispit.ocjena < 6 || ispit.ocjena > 10);

            System.Console.WriteLine("Unesi datum ispita: ");
            ispit.datum = SafeInputDateTime();

            return ispit;
        }
        

        public Katedra InputKatedra()
        {
            Katedra katedra = new Katedra();
            List<Katedra> katedre = manager_katedra.GetAllKatedre();
            int sifra;

            do {
                System.Console.WriteLine("Unesi sifru katedre: ");
                sifra = SafeInputInt();
                
            } while (katedre.Find(k=>k.sifra_katedre==sifra)!=null);
            katedra.sifra_katedre = sifra;
            System.Console.WriteLine("Unesi naziv katedre: ");
            string naziv = System.Console.ReadLine();
            katedra.naziv_katedre = naziv;

            
                System.Console.WriteLine("Unesi id sefa katedre: ");
                katedra.idSefaKatedra = SafeInputInt();

            

            
            return katedra;

        }

        public Adresa InputAdresa()
        {
            Adresa adr = new Adresa();
            List<Adresa> adrese = manager_adresa.GetAllAdrese();
            int id;
            do {
                System.Console.WriteLine("Unesi id adrese: ");
                id = SafeInputInt();
                
            } while (adrese.Find(a => a.id_adr == id)!=null);
            adr.id_adr = id;

            System.Console.WriteLine("Unesi ulicu: ");
            string naziv = System.Console.ReadLine();
            adr.ulica = naziv;

            System.Console.WriteLine("Unesi broj: ");
            int br = SafeInputInt();
            adr.broj = br;

            System.Console.WriteLine("Unesi grad: ");
            string gr = System.Console.ReadLine();
            adr.grad = gr;

            System.Console.WriteLine("Unesi drzavu: ");
            string dr = System.Console.ReadLine();
            adr.drzava = dr;


            return adr;

        }


        private int InputIdStudent()
        {
            System.Console.WriteLine("Unesi id studenta: ");
            return SafeInputInt();
        }

        private int InputIdProfesor()
        {
            System.Console.WriteLine("Unesi id profesora: ");
            return SafeInputInt();
        }

        private string InputIdPredmet()
        {
            System.Console.WriteLine("Unesi sifru predmeta: ");
            string sifra = System.Console.ReadLine();
            return sifra;
        }

        private int InputIdIspita()
        {
            System.Console.WriteLine("Unesi id ispita: ");
            return SafeInputInt();

        }
        
        
        private int InputIdKatedra()
        {
            System.Console.WriteLine("Unesi sifru katedre: ");
            int sifra = SafeInputInt();
            return sifra;
        }

        private int InputIdAdrese()
        {

            System.Console.WriteLine("Unesi id adrese: ");
            return SafeInputInt();
        }


        public void RunMenu()
        {
            while (true)
            {
                ShowMenu();

                List<Predmet> predmeti = manager_predmet.GetAllPredmets();//pribavlja trenutne podatke iz txt fajlova
                List<Profesor> profesori = manager_profesor.GetAllProfesors();
                List<Student> studenti = manager_student.GetAllStudents();
                List<OcenaNaIspitu> ispiti = manager_ispit.GetAllIspits();
                List<Katedra> katedre = manager_katedra.GetAllKatedre();
                List<Adresa> adrese = manager_adresa.GetAllAdrese();




                foreach (Profesor p in profesori)//pronalazi adresu kancelarije profesora u tabeli adrese
                {
                    Adresa adr = adrese.Find(a => a.id_adr == p.adresa_kancelarije_id);
                    p.adresa_kancelarije = adr;
                }

                foreach (Profesor p in profesori)//pronalazi adresu profesora u tabeli adrese
                {
                    Adresa adr = adrese.Find(a => a.id_adr == p.adresa_stanovanja_id);
                    p.adresa_profesora = adr;
                }


                foreach (Student s in studenti)//pronalazi adresu studenta u tabeli adrese
                {
                    Adresa adr = adrese.Find(a => a.id_adr == s.adresa_stanovanja_id);
                    s.adresa_studenta = adr;
                }


                foreach (Predmet pr in predmeti)//uvezuje profesore i predmete gdje predaju
                {
                    Profesor prof = profesori.Find(p => p.ime + " " + p.prezime == pr.predmetni_profesor);
                    if (prof.predmeti_gdje_predaje.Find(t => pr.sifra_predmeta == t.sifra_predmeta) == null)//provjerava da li je predmet vec u listi
                    {
                        prof.predmeti_gdje_predaje.Add(pr);
                    }
                }

                foreach (OcenaNaIspitu i in ispiti)//uvezuje ispite sa studentima i predmetima koji su na njemu ucestvovali
                {
                    Student st = studenti.Find(p => p.Id == i.idStudenta);
                    Predmet pr = predmeti.Find(pe => pe.sifra_predmeta == i.sifraPredmeta);
                    if (st.polozeniPredmeti.Find(t=>t.sifra_predmeta==pr.sifra_predmeta)==null && pr.studenti_koji_su_polozili.Find(m=>m.Id==st.Id)==null)
                    {
                        if (st.trenutna_godina_studija == pr.godina_studija_ukojoj_se_predmet_izvodi)
                        {
                            st.polozeniPredmeti.Add(pr);
                            pr.studenti_koji_su_polozili.Add(st);
                        }
                    }
                }

                foreach (Student student in studenti)//uvezuje studente i predmete koji gdje student nije polozio predmet
                {
                    foreach (Predmet predmet in predmeti)
                    {
                        if (predmet.godina_studija_ukojoj_se_predmet_izvodi == student.trenutna_godina_studija//provjerava da li se predmet izvodi u istoj godini kao i godina studiranja studenta
                            && student.polozeniPredmeti.Find(t => predmet.sifra_predmeta == t.sifra_predmeta) == null)//provjerava da ispit nije polozen
                        {
                            if (student.nepolozeniPredmeti.Find(m => m.sifra_predmeta == predmet.sifra_predmeta) == null && predmet.studenti_koji_nisu_polozili.Find(d => d.Id == student.Id) == null)
                            {//provjerava da li je predmet vec dodat u liste nepolozeniPredmeti i studenti_koji_nisu_polozili
                                
                                    student.nepolozeniPredmeti.Add(predmet);
                                    predmet.studenti_koji_nisu_polozili.Add(student);
                                
                            }
                        }

                    }


                }

                foreach(Profesor p in profesori)
                {
                    
                    Katedra k = katedre.Find(kat => kat.sifra_katedre == p.id_katedre);
                    if (k.profesori_na_katedri.Find(t => t.Id == p.Id) == null)
                    {
                        k.profesori_na_katedri.Add(p);
                        
                    }
                    
                    
                    
                }

                //uvezujem id_sefa katedre iz klase katedra sa konkretnim profesorom
                foreach(Katedra k in katedre)
                {
                    Profesor prof = profesori.Find(p => p.Id == k.idSefaKatedra);
                    k.sef_katedre = prof;                 
                }

                string userInput = System.Console.ReadLine();
                if (userInput == "0") break;
                HandleMenuInput(userInput);
            }
        }


        private void HandleMenuInput(string input)
        {
            switch (input)
            {
                case "1":
                    System.Console.WriteLine("\nIzaberite neku od opcija: ");
                    System.Console.WriteLine("1: Izlistaj sve studente");
                    System.Console.WriteLine("2: Dodaj studenta");
                    System.Console.WriteLine("3: Izmeni postojeceg studenta");
                    System.Console.WriteLine("4: Izbrisi studenta");
                    System.Console.WriteLine("0: Vrati se na glavni meni");


                    string userInputStudent = System.Console.ReadLine();
                    if (userInputStudent == "0") break;

                    switch (userInputStudent)
                    {
                        case "1":
                            PrintStudents(manager_student.GetAllStudents());
                            break;
                        case "2":
                            AddStudent();
                            break;
                        case "3":
                            UpdateStudent();
                            break;
                        case "4":
                            RemoveStudent();
                            break;
                    }
                    break;
                case "2":

                    System.Console.WriteLine("\nIzaberite neku od opcija: ");
                    System.Console.WriteLine("1: Izlistaj sve profesore");
                    System.Console.WriteLine("2: Dodaj profesora");
                    System.Console.WriteLine("3: Izmeni postojeceg profesora");
                    System.Console.WriteLine("4: Izbrisi profesora");
                    System.Console.WriteLine("0: Vrati se na glavni meni");

                    string userInputProfesor = System.Console.ReadLine();
                    if (userInputProfesor == "0") break;

                    switch (userInputProfesor)
                    {
                        case "1":
                            PrintProfesors(manager_profesor.GetAllProfesors());
                            break;
                        case "2":
                            AddProfesor();
                            break;
                        case "3":
                            UpdateProfesor();
                            break;
                        case "4":
                            RemoveProfesor();
                            break;
                    }
                    break;

                case "3":

                    System.Console.WriteLine("\nIzaberite neku od opcija: ");
                    System.Console.WriteLine("1: Izlistaj sve predmete");
                    System.Console.WriteLine("2: Dodaj predmet");
                    System.Console.WriteLine("3: Izmeni postojeci predmet");
                    System.Console.WriteLine("4: Izbrisi predmet");
                    System.Console.WriteLine("0: Vrati se na glavni meni");

                    string userInputPredmet = System.Console.ReadLine();
                    if (userInputPredmet == "0") break;
                    switch (userInputPredmet)
                    {
                        case "1":
                            PrintPredmets(manager_predmet.GetAllPredmets());
                            break;
                        case "2":
                            AddPredmet();
                            break;
                        case "3":
                            UpdatePredmet();
                            break;
                        case "4":
                            RemovePredmet();
                            break;
                    }
                    break;

                case "4":

                    System.Console.WriteLine("\nIzaberite neku od opcija: ");
                    System.Console.WriteLine("1: Izlistaj sve ispite");
                    System.Console.WriteLine("2: Dodaj ispit");
                    System.Console.WriteLine("3: Izmeni postojeci ispit");
                    System.Console.WriteLine("4: Izbrisi ispit");
                    System.Console.WriteLine("0: Vrati se na glavni meni");

                    string userInputIspit = System.Console.ReadLine();
                    if (userInputIspit == "0") break;
                    switch (userInputIspit)
                    {
                        case "1":
                            PrintIspits(manager_ispit.GetAllIspits());
                            break;
                        case "2":
                            AddIspit();
                            break;
                        case "3":
                            UpdateIspit();
                            break;
                        case "4":
                            RemoveIspit();
                            break;
                    }
                    break;

                case "5":

                    System.Console.WriteLine("\nIzaberite neku od opcija: ");
                    System.Console.WriteLine("1: Izlistaj sve katedre");
                    System.Console.WriteLine("2: Dodaj katedru");
                    System.Console.WriteLine("3: Izmeni postojecu katedru");
                    System.Console.WriteLine("4: Izbrisi katedru");
                    System.Console.WriteLine("0: Vrati se na glavni meni");

                    string userInputKatedra = System.Console.ReadLine();
                    if (userInputKatedra == "0") break;

                    switch (userInputKatedra)
                    {
                        case "1":
                            PrintKatedre(manager_katedra.GetAllKatedre());
                            break;
                        case "2":
                            AddKatedra();
                            break;
                        case "3":
                            UpdateKatedra();
                            break;
                        case "4":
                            RemoveKatedra();
                            break;
                    }
                    break;

                case "6":

                    System.Console.WriteLine("\nIzaberite neku od opcija: ");
                    System.Console.WriteLine("1: Izlistaj sve adrese");
                    System.Console.WriteLine("2: Dodaj adresu");
                    System.Console.WriteLine("3: Izmeni postojecu adresu");
                    System.Console.WriteLine("4: Izbrisi adresu");
                    System.Console.WriteLine("0: Vrati se na glavni meni");

                    string userInputAdresa = System.Console.ReadLine();
                    if (userInputAdresa == "0") break;

                    switch (userInputAdresa)
                    {
                        case "1":
                            PrintAdrese(manager_adresa.GetAllAdrese());
                            break;
                        case "2":
                            AddAdresa();
                            break;
                        case "3":
                            UpdateAdresa();
                            break;
                        case "4":
                            RemoveAdresa();
                            break;
                    }
                    break;
            }
        }

        private void RemoveStudent()
        {
            int id = InputIdStudent();
            Student removedStudent = manager_student.RemoveStudent(id);
            if (removedStudent == null)
            {
                System.Console.WriteLine("Student sa id-om " + id + " nije pronadjen");
                return;
            }
            System.Console.WriteLine("Student izbrisan");
        }

        private void RemoveProfesor()
        {
            int id = InputIdProfesor();
            Profesor removedProfesor = manager_profesor.RemoveProfesor(id);
            if (removedProfesor == null)
            {
                System.Console.WriteLine("Profesor sa id-om " + id + " nije pronadjen");
                return;
            }
            System.Console.WriteLine("Profesor izbrisan");
        }

        private void RemovePredmet()
        {
            string sifra = InputIdPredmet();
            Predmet removedPredmet = manager_predmet.RemovePredmet(sifra);
            if (removedPredmet == null)
            {
                System.Console.WriteLine("Predmet sa sifrom " + sifra + " nije pronadjen");
                return;
            }
            System.Console.WriteLine("Predmet izbrisan");
        }

        private void RemoveIspit()
        {
            int id = InputIdIspita();
            OcenaNaIspitu removedIspit = manager_ispit.RemoveIspit(id);
            if (removedIspit == null)
            {
                System.Console.WriteLine("Ispit sa id-om " + id + " nije pronadjen");
                return;
            }
            System.Console.WriteLine("Ispit izbrisan");
        }


        private void RemoveKatedra()
        {
            int sifra = InputIdKatedra();
            Katedra izbrisanaKatedra = manager_katedra.IzbrisiKatedru(sifra);
            if (izbrisanaKatedra == null)
            {
                System.Console.WriteLine("Katedra sa sifrom " + sifra + " nije pronadjena");
                return;
            }
            System.Console.WriteLine("Katedra izbrisana");
        }

        private void RemoveAdresa()
        {
            int sifra = InputIdAdrese();
            Adresa izbrisanaAdresa = manager_adresa.IzbrisiAdresu(sifra);
            if (izbrisanaAdresa == null)
            {
                System.Console.WriteLine("Adresa sa id: " + sifra + " nije pronadjena");
                return;
            }
            System.Console.WriteLine("Adresa izbrisana");
        }

        private void UpdateStudent()
        {
            int id = InputIdStudent();
            Student student = InputStudent();
            student.Id = id;
            Student updatedStudent = manager_student.UpdateStudent(student);
            if (updatedStudent == null)
            {
                System.Console.WriteLine("Student sa id-om " + id + " nije pronadjen");
                return;
            }
           
            System.Console.WriteLine("Student izmjenjen");
        }

        private void UpdateProfesor()
        {
            int id = InputIdProfesor();
            Profesor profesor = InputProfesor();
            profesor.Id = id;
            Profesor updatedProfesor = manager_profesor.UpdateProfesor(profesor);
            if (updatedProfesor == null)
            {
                System.Console.WriteLine("Profesor sa id-om " + id + " nije pronadjen");
                return;
            }

            System.Console.WriteLine("Profesor izmjenjen");
        }
        
        private void UpdatePredmet()
        {
            string sifra = InputIdPredmet();
            Predmet predmet = manager_predmet.GetPredmetById(sifra);
            if(predmet == null)
            {
                System.Console.WriteLine("Predmet sa sifrom " + sifra + " nije pronadjen");
                return;
            }

            
            Predmet updatedPredmet = manager_predmet.UpdatePredmet(predmet);
           

            System.Console.WriteLine("Predmet izmjenjen");
        }

        private void UpdateIspit()
        {
            int id = InputIdIspita();
            OcenaNaIspitu ispit = InputIspit();
            ispit.idIspita = id;
            OcenaNaIspitu updatedIspit = manager_ispit.UpdateIspit(ispit);
            if (updatedIspit == null)
            {
                System.Console.WriteLine("Ispit sa id-om " + id + " nije pronadjen");
                return;
            }

            System.Console.WriteLine("Ispit izmjenjen");
        }


        private void UpdateKatedra()
        {
            int sifra = InputIdKatedra();
            Katedra katedra = manager_katedra.GetKatedraById(sifra);
            if (katedra == null)
            {
                System.Console.WriteLine("Katedra sa sifrom " + sifra + " nije pronadjena");
                return;
            }

            Katedra nova_katedra = InputKatedra();


            Katedra updatedKatedra = manager_katedra.UpdateKatedra(katedra,nova_katedra);


            System.Console.WriteLine("Katedra izmjenjena");
        }

        private void UpdateAdresa()
        {
            int sifra = InputIdAdrese();
            Adresa adr = manager_adresa.GetAdresaById(sifra);
            if (adr == null)
            {
                System.Console.WriteLine("Adresa sa id: " + sifra + " nije pronadjena");
                return;
            }

            Adresa nova_adresa = InputAdresa();


            Adresa updatedAdresa = manager_adresa.UpdateAdresa(adr, nova_adresa);


            System.Console.WriteLine("Adresa izmjenjena");
        }

        private void AddStudent()
        {
            Student student = InputStudent();
            manager_student.AddStudent(student);
            System.Console.WriteLine("Student dodat");
        }

        private void AddProfesor()
        {
            Profesor profesor = InputProfesor();
            manager_profesor.AddProfesor(profesor);
            System.Console.WriteLine("Profesor dodat");
        }

        private void AddPredmet()
        {
            Predmet predmet = InputPredmet();
            manager_predmet.AddPredmet(predmet);
            System.Console.WriteLine("Predmet dodat");
        }
        private void AddIspit()
        {
            OcenaNaIspitu ispit = InputIspit();
            manager_ispit.AddIspit(ispit);
            System.Console.WriteLine("Ispit dodat");
        }

        private void AddKatedra()
        {
            Katedra katedra = InputKatedra();
            manager_katedra.DodajKatedru(katedra);
            System.Console.WriteLine("Katedra dodata");
        }

        private void AddAdresa()
        {
            Adresa adr = InputAdresa();
            manager_adresa.DodajAdresu(adr);
            System.Console.WriteLine("Adresa dodata");
        }

        private void ShowMenu()
        {
            System.Console.WriteLine("\nIzaberite neki od seldecih entiteta: ");
            System.Console.WriteLine("1: Student");
            System.Console.WriteLine("2: Profesor");
            System.Console.WriteLine("3: Predmet");
            System.Console.WriteLine("4: Ispit");
            System.Console.WriteLine("5: Katedra");
            System.Console.WriteLine("6: Adresa");
            System.Console.WriteLine("0: Izadji");


         
        }


    }
}
