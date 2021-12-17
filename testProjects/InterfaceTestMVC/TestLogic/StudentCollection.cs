using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Data;

namespace TestLogic
{
    public class StudentCollection
    {
        private StudentFactory studentFactory = new StudentFactory();
        public List<Student> Students = new List<Student>();
        DAL dal = new DAL();
        public StudentCollection() {
            foreach (var studentDto in dal.GetAllStudents())
            {
                Students.Add(new Student(studentDto));
            }
            studentFactory = new StudentFactory();
        }
        
    }
}
