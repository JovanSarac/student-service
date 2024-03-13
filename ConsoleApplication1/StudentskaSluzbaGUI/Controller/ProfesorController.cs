using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzbaGUI.ModelDAO;
using StudentskaSluzbaGUI.Controller;
using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Observer;


namespace StudentskaSluzbaGUI.Controller
{
    public class ProfesorController
    {
        private ProfesorDAO profesori;

        public ProfesorController()
        {
            profesori = new ProfesorDAO();
        }

        public List<Profesor> GetAllProfesor()
        {
            return profesori.GetAll();
        }

        public void Create(Profesor profesor)
        {
            profesori.Add(profesor);
        }

        public void Delete(Profesor profesor)
        {
            profesori.Remove(profesor);
        }

        public void Update(Profesor profesor)
        {
            profesori.Update(profesor);
        }

        public void Subscribe(IObserver observer)
        {
            profesori.Subscribe(observer);
        }
    }
}
