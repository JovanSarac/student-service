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
    public class IspitController
    {
        private IspitDAO ispiti;

        public IspitController()
        {
            ispiti = new IspitDAO();
        }

        public List<OcenaNaIspitu> GetAllIspit()
        {
            return ispiti.GetAll();
        }

        

        public void Create(OcenaNaIspitu ispit)
        {
            ispiti.Add(ispit);
        }

        public void Delete(OcenaNaIspitu ispit)
        {
            ispiti.Remove(ispit);
        }
        /*
        public void Update(OcenaNaIspitu ispit)
        {
            ispiti.Update(ispit);
        }*/

        public void Subscribe(IObserver observer)
        {
            ispiti.Subscribe(observer);
        }
    }
}