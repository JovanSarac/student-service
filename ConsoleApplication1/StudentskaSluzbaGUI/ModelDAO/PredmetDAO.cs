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
    class PredmetDAO:ISubject
    {
        private List<IObserver> _observers;

        private PredmetStorage _storage;
        private List<Predmet> predmeti;

        public PredmetDAO()
        {
            _storage = new PredmetStorage();
            predmeti = _storage.Load();
            _observers = new List<IObserver>();
        }

        

        public void Add(Predmet predmet)
        {
            
            predmeti.Add(predmet);
            _storage.Save(predmeti);
            NotifyObservers();
        }

        public void Remove(Predmet predmet)
        {
            predmeti.Remove(predmet);
            _storage.Save(predmeti);
            NotifyObservers();
        }

        public void Update(Predmet predmet)
        {
            int index = predmeti.FindIndex(p => p.sifra_predmeta == predmet.sifra_predmeta);
            if(index != -1)
            {
                predmeti[index] = predmet;
            }

            _storage.Save(predmeti);
            NotifyObservers();
        }

        public List<Predmet> GetAll()
        {
            return predmeti;
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
