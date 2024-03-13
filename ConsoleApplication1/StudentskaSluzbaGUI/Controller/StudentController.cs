using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentskaSluzbaGUI.ModelDAO;
using ConsoleApplication1.model;
using StudentskaSluzbaGUI.Observer;

namespace StudentskaSluzbaGUI.Controller
{
    public class StudentController
    {
        private StudentDAO _students;

        public StudentController()
        {
            _students = new StudentDAO();
        }

        public List<Student> GetAllStudents()
        {
            return _students.GetAll();
        }

        public void Create(Student student)
        {
            _students.Add(student);
        }

        public void Delete(Student student)
        {
            _students.Remove(student);
        }

        public void Update(Student student)
        {
            _students.Update(student);
        }

        public void Subscribe(IObserver observer)
        {
            _students.Subscribe(observer);
        }
    }
}
