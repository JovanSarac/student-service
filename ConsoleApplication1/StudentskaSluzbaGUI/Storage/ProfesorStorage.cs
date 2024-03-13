using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.model;
using ConsoleApplication1.Manager.Serialization;


namespace StudentskaSluzbaGUI.Storage
{
    class ProfesorStorage
    {
        private const string StoragePath = "../../Data/profesori.csv";

        private Serializer<Profesor> _serializer;


        public ProfesorStorage()
        {
            _serializer = new Serializer<Profesor>();
        }

        public List<Profesor> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Profesor> profesori)
        {
            _serializer.ToCSV(StoragePath, profesori);
        }

    }
}
