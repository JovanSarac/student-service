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
    public class PredmetController
    {
        private PredmetDAO predmeti;

        public PredmetController()
        {
            predmeti = new PredmetDAO();
        }

        public List<Predmet> GetAllPredmet()
        {
            return predmeti.GetAll();
        }

        public List<Predmet> GetSomePredmet(int br)
        {
            List<Predmet> predmets = new List<Predmet>();
            foreach (var predmet in predmeti.GetAll())
            {
                if (predmet.godina_studija_ukojoj_se_predmet_izvodi <= br)
                {
                    predmets.Add(predmet);
                }
            }
            return predmets;

        }

        public void Create(Predmet predmet)
        {
            predmeti.Add(predmet);
        }

        public void Delete(Predmet predmet)
        {
            predmeti.Remove(predmet);
        }

        public void Update(Predmet predmet)
        {
            predmeti.Update(predmet);
        }

        public void Subscribe(IObserver observer)
        {
            predmeti.Subscribe(observer);
        }
    }
}
