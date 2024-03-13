using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;

namespace StudentskaSluzbaGUI.Storage
{
    class IspitStorage
    {
        private const string StoragePath = "../../Data/ispiti.csv";

        private Serializer<OcenaNaIspitu> _serializer;


        public IspitStorage()
        {
            _serializer = new Serializer<OcenaNaIspitu>();
        }

        public List<OcenaNaIspitu> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<OcenaNaIspitu> ispiti)
        {
            _serializer.ToCSV(StoragePath, ispiti);
        }
    }
}
