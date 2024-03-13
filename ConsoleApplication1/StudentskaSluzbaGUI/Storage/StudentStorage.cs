using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;

namespace StudentskaSluzbaGUI.Storage
{
    class StudentStorage
    {

        private const string StoragePath = "../../Data/studenti.csv";

        private Serializer<Student> _serializer;


        public StudentStorage()
        {
            _serializer = new Serializer<Student>();
        }

        public List<Student> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Student> students)
        {
            _serializer.ToCSV(StoragePath, students);
        }
    }
}
