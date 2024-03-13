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
    public class KatedreController
    {
        private KatedreDAO katedre;

        public KatedreController()
        {
            katedre = new KatedreDAO();
        }

        public List<Katedra> GetAllKatedra()
        {
            return katedre.GetAll();
        }

       

        public void Create(Katedra k)
        {
            katedre.Add(k);
        }

        public void Delete(Katedra k)
        {
            katedre.Remove(k);
        }

        

        public void Subscribe(IObserver observer)
        {
            katedre.Subscribe(observer);
        }
    }
}
