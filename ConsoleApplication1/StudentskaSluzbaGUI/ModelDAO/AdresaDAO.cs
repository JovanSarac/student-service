using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Observer;
using StudentskaSluzbaGUI.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzbaGUI.ModelDAO
{
    class AdresaDAO : ISubject
    {

        private List<IObserver> _observers;

        private AdresaStorage _storage;
        private List<Adresa> _adrese;

        public AdresaDAO()
        {
            _storage = new AdresaStorage();
            _adrese = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _adrese.Max(a => a.id_adr) + 1;
        }

        public void Add(Adresa adresa)
        {
            adresa.id_adr = NextId();
            _adrese.Add(adresa);
            _storage.Save(_adrese);
            NotifyObservers();
        }

        public void Remove(Adresa adresa)
        {
            _adrese.Remove(adresa);
            _storage.Save(_adrese);
            NotifyObservers();
        }

        public void Update(Adresa adresa)
        {

            int index = _adrese.FindIndex(a => a.id_adr == adresa.id_adr);
            if (index != -1)
            {
                _adrese[index] = adresa;
            }
            _storage.Save(_adrese);
            NotifyObservers();



        }

        public List<Adresa> GetAll()
        {
            return _adrese;
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
