using ConsoleApplication1.model;
using StudentskaSluzbaGUI.ModelDAO;
using StudentskaSluzbaGUI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzbaGUI.Controller
{
    public class AdresaController
    {
        private AdresaDAO _adrese;

        public AdresaController()
        {
            _adrese = new AdresaDAO();
        }

        public List<Adresa> GetAllAdrese()
        {
            return _adrese.GetAll();
        }

        public void Create(Adresa adresa)
        {
            _adrese.Add(adresa);
        }

        public void Delete(Adresa adresa)
        {
            _adrese.Remove(adresa);
        }

        public void Update(Adresa adresa)
        {
            _adrese.Update(adresa);
        }

        public void Subscribe(IObserver observer)
        {
            _adrese.Subscribe(observer);
        }
    }
}
