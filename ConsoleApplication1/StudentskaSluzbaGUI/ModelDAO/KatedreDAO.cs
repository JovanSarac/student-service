using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzbaGUI.Observer;
using StudentskaSluzbaGUI.Storage;
using ConsoleApplication1.model;
using StudentskaSluzbaGUI.ModelDAO;

namespace StudentskaSluzbaGUI.ModelDAO
{
    class KatedreDAO : ISubject
    {
        private List<IObserver> _observers;

        private KatedraStorage _storage;
        private List<Katedra> katedre;

        public KatedreDAO()
        {
            _storage = new KatedraStorage();
            katedre = _storage.Load();
            _observers = new List<IObserver>();
        }



        public void Add(Katedra k)
        {

            katedre.Add(k);
            _storage.Save(katedre);
            NotifyObservers();
        }

        public void Remove(Katedra k)
        {
            katedre.Remove(k);
            _storage.Save(katedre);
            NotifyObservers();
        }

        

        public List<Katedra> GetAll()
        {
            return katedre;
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