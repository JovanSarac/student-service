using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzbaGUI.Storage
{
    class AdresaStorage
    {
        private const string StoragePath = "../../Data/adrese.csv";

        private Serializer<Adresa> _serializer;


        public AdresaStorage()
        {
            _serializer = new Serializer<Adresa>();
        }

        public List<Adresa> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Adresa> adrese)
        {
            _serializer.ToCSV(StoragePath, adrese);
        }
    }
}
