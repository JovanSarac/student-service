using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Manager
{
    public class StudentManager
    {
        private List<Student> studenti;
        private Serializer<Student> serializer;

        private readonly string fileName = "studenti.txt";

        public StudentManager()
        {
            serializer = new Serializer<Student>();
            LoadStudents();
        }

        private void LoadStudents()
        {
            studenti = serializer.FromCSV(fileName);
        }

        private void SaveStudents()
        {
            serializer.ToCSV(fileName, studenti);
        }

        private int GenerateId()
        {
            if (studenti.Count == 0) return 0;
            return studenti[studenti.Count - 1].Id + 1;
        }

        public Student AddStudent(Student student)
        {
            student.Id = GenerateId();
            studenti.Add(student);
            SaveStudents();
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            Student oldStudent = GetStudenById(student.Id);
            if (oldStudent == null) return null;

            oldStudent.ime = student.ime;
            oldStudent.prezime = student.prezime;
            oldStudent.datum_rodjenja = student.datum_rodjenja;
            oldStudent.adresa_stanovanja_id = student.adresa_stanovanja_id;
            oldStudent.telefon = student.telefon;
            oldStudent.email = student.email;
            oldStudent.broj_indeksa = student.broj_indeksa;
            oldStudent.godina_upisa = student.godina_upisa;
            oldStudent.trenutna_godina_studija = student.trenutna_godina_studija;
            oldStudent.nacin_finansiranja = student.nacin_finansiranja;
            oldStudent.prosecna_ocena = student.prosecna_ocena;

            SaveStudents();
            return oldStudent;
        }

        public Student RemoveStudent(int id)
        {
            Student student = GetStudenById(id);
            if (student == null) return null;

            studenti.Remove(student);
            SaveStudents();
            return student;
        }

        public Student GetStudenById(int id)
        {
            return studenti.Find(v => v.Id == id);
        }

        public List<Student> GetAllStudents()
        {
            return studenti;
        }
    }
}
