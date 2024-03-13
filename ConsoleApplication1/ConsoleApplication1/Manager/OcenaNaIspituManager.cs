using System;
using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Manager
{
    class OcenaNaIspituManager
    {
        private List<OcenaNaIspitu> ispiti;
        private Serializer<OcenaNaIspitu> serializer;
        private readonly string fileName = "ispiti.txt";


        public OcenaNaIspituManager()
        {
            serializer = new Serializer<OcenaNaIspitu>();
            LoadIspits();
        }

        private void LoadIspits()
        {
            ispiti = serializer.FromCSV(fileName);
        }

        private void SaveIspits()
        {
            serializer.ToCSV(fileName, ispiti);
        }

        private int GenerateId()
        {
            if (ispiti.Count == 0) return 0;
            return ispiti[ispiti.Count - 1].idIspita + 1;
        }



        public OcenaNaIspitu AddIspit(OcenaNaIspitu ispit)
        {
            ispit.idIspita = GenerateId();
            ispiti.Add(ispit);
            SaveIspits();
            return ispit;
        }

        public OcenaNaIspitu UpdateIspit(OcenaNaIspitu ispit)
        {
            OcenaNaIspitu oldIspit = GetIspitById(ispit.idIspita);
            if (oldIspit == null) return null;

            oldIspit.idStudenta = ispit.idStudenta;
            oldIspit.sifraPredmeta = ispit.sifraPredmeta;
            oldIspit.ocjena = ispit.ocjena;
            oldIspit.datum = ispit.datum;
            

            SaveIspits();
            return oldIspit;
        }

        public OcenaNaIspitu RemoveIspit(int id)
        {
            OcenaNaIspitu ispit = GetIspitById(id);
            if (ispit == null) return null;

            ispiti.Remove(ispit);
            SaveIspits();
            return ispit;
        }

        public OcenaNaIspitu GetIspitById(int id)
        {
            return ispiti.Find(v => v.idIspita == id);
        }

        public List<OcenaNaIspitu> GetAllIspits()
        {
            return ispiti;
        }

    }
       
}
