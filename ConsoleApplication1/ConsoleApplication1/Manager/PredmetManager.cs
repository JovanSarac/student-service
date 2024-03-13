using System;
using ConsoleApplication1.model;
using ConsoleApplication1.Manager.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Manager
{
    public class PredmetManager
    {
        private List<Predmet> predmeti;
        private Serializer<Predmet> serializer;

        private readonly string fileName = "predmeti.txt";

        public PredmetManager()
        {
            serializer = new Serializer<Predmet>();
            LoadPredmets();
        }

        private void LoadPredmets()
        {
            predmeti = serializer.FromCSV(fileName);
        }

        private void SavePredmets()
        {
            serializer.ToCSV(fileName, predmeti);
        }

        

        public Predmet AddPredmet( Predmet predmet)
        {
            
            predmeti.Add(predmet);
            SavePredmets();
            return predmet;
        }

        public Predmet UpdatePredmet(Predmet predmet)
        {
            Predmet oldPredmet = GetPredmetById(predmet.sifra_predmeta);
            if (oldPredmet == null) return null;

            oldPredmet.naziv_predmeta = predmet.naziv_predmeta;
            oldPredmet.semestar = predmet.semestar;
            oldPredmet.godina_studija_ukojoj_se_predmet_izvodi = predmet.godina_studija_ukojoj_se_predmet_izvodi;
            oldPredmet.predmetni_profesor = predmet.predmetni_profesor;
            oldPredmet.broj_ESPB = predmet.broj_ESPB;

            SavePredmets();
            return oldPredmet;
        }

        public Predmet RemovePredmet(string id)
        {
            Predmet predmet = GetPredmetById(id);
            if (predmet == null) return null;

            predmeti.Remove(predmet);
            SavePredmets();
            return predmet;
        }

        public Predmet GetPredmetById(string id)
        {
            return predmeti.Find(v => v.sifra_predmeta == id);
        }

        public List<Predmet> GetAllPredmets()
        {
            return predmeti;
        }
    }
}
