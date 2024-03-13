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
    class IspitDAO : ISubject
    {
        private List<IObserver> _observers;

        private IspitStorage _storage;
        private List<OcenaNaIspitu> ispiti;

        public IspitDAO()
        {
            _storage = new IspitStorage();
            ispiti = _storage.Load();
            _observers = new List<IObserver>();
        }



        public void Add(OcenaNaIspitu ispit)
        {

            ispiti.Add(ispit);
            _storage.Save(ispiti);
            NotifyObservers();
        }

        public void Remove(OcenaNaIspitu ispit)
        {
            ispiti.Remove(ispit);
            _storage.Save(ispiti);
            NotifyObservers();
        }
        /*
        public void Update(OcenaNaIspitu ispit)
        {
            int index = ispiti.FindIndex(p => p.sifra_predmeta == predmet.sifra_predmeta);
            if (index != -1)
            {
                predmeti[index] = predmet;
            }

            _storage.Save(predmeti);
            NotifyObservers();
        }
        */
        public List<OcenaNaIspitu> GetAll()
        {
            return ispiti;
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
