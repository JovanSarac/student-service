using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzbaGUI.Observer;
using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Storage;

namespace StudentskaSluzbaGUI.ModelDAO
{
    class StudentDAO : ISubject
    {
        private List<IObserver> _observers;

        private StudentStorage _storage;
        private List<Student> _students;

        public StudentDAO()
        {
            _storage = new StudentStorage();
            _students = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _students.Max(s => s.Id) + 1;
        }

        public void Add(Student student)
        {
            student.Id = NextId();
            _students.Add(student);
            _storage.Save(_students);
            NotifyObservers();
        }

        public void Remove(Student student)
        {
            _students.Remove(student);
            _storage.Save(_students);
            NotifyObservers();
        }

        public void Update(Student student)
        {

            int index =  _students.FindIndex(s => s.Id == student.Id);
            if (index != -1)
            {
                _students[index] = student;
            }
            _storage.Save(_students);
            NotifyObservers();
            


        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
