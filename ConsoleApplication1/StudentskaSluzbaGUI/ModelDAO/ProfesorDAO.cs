using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzbaGUI.Observer;
using StudentskaSluzbaGUI.Storage;
using ConsoleApplication1.model;

namespace StudentskaSluzbaGUI.ModelDAO
{
    class ProfesorDAO:ISubject
    {
        private List<IObserver> _observers;

        private ProfesorStorage _storage;
        private List<Profesor> profesori;

        public ProfesorDAO()
        {
            _storage = new ProfesorStorage();
            profesori = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return profesori.Max(s => s.Id) + 1;
        }

        public void Add(Profesor profesor)
        {
            profesor.Id = NextId();
            profesori.Add(profesor);
            _storage.Save(profesori);
            NotifyObservers();
        }

        public void Remove(Profesor profesor)
        {
            profesori.Remove(profesor);
            _storage.Save(profesori);
            NotifyObservers();
        }

        public void Update(Profesor profesor)
        {
            int index = profesori.FindIndex(p => p.Id == profesor.Id);
            if(index != -1)
            {
                profesori[index] = profesor;
            }

            _storage.Save(profesori);
            NotifyObservers();
        }

        public List<Profesor> GetAll()
        {
            return profesori;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
