using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;

namespace StudentskaSluzbaGUI.Storage
{
    class KatedraStorage
    {
        private const string StoragePath = "../../Data/katedre.csv";

        private Serializer<Katedra> _serializer;


        public KatedraStorage()
        {
            _serializer = new Serializer<Katedra>();
        }

        public List<Katedra> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Katedra> katedre)
        {
            _serializer.ToCSV(StoragePath, katedre);
        }
    }
}
