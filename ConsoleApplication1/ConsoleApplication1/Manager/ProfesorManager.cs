using System;
using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1.Manager
{
    public class ProfesorManager
    {
        private List<Profesor> profesori;
        private Serializer<Profesor> serializer;

        private readonly string fileName = "profesori.txt";

        public ProfesorManager()
        {
            serializer = new Serializer<Profesor>();
            LoadProfesors();
        }

        private void LoadProfesors()
        {
            profesori = serializer.FromCSV(fileName);
        }

        private void SaveProfesors()
        {
            serializer.ToCSV(fileName, profesori);
        }

        private int GenerateId()
        {
            if (profesori.Count == 0) return 0;
            return profesori[profesori.Count - 1].Id + 1;
        }

        public Profesor AddProfesor(Profesor profesor)
        {
            profesor.Id = GenerateId();
            profesori.Add(profesor);
            SaveProfesors();
            return profesor;
        }

        public Profesor UpdateProfesor(Profesor profesor)
        {
            Profesor oldProfesor = GetProfesorById(profesor.Id);
            if (oldProfesor == null) return null;

            oldProfesor.ime = profesor.ime;
            oldProfesor.prezime = profesor.prezime;
            oldProfesor.datum_rodjenja = profesor.datum_rodjenja;
            oldProfesor.adresa_stanovanja_id = profesor.adresa_stanovanja_id;
            oldProfesor.kontakt_telefon = profesor.kontakt_telefon;
            oldProfesor.email = profesor.email;
            oldProfesor.adresa_kancelarije = profesor.adresa_kancelarije;
            oldProfesor.broj_licne = profesor.broj_licne;
            oldProfesor.zvanje = profesor.zvanje;
            oldProfesor.godine_staza = profesor.godine_staza;
            oldProfesor.id_katedre = profesor.id_katedre;

            SaveProfesors();
            return oldProfesor;
        }

        public Profesor RemoveProfesor(int id)
        {
            Profesor profesor = GetProfesorById(id);
            if (profesor == null) return null;

            profesori.Remove(profesor);
            SaveProfesors();
            return profesor;
        }

        public Profesor GetProfesorById(int id)
        {
            return profesori.Find(v => v.Id == id);
        }

        public List<Profesor> GetAllProfesors()
        {
            return profesori;
        }
    }
}
