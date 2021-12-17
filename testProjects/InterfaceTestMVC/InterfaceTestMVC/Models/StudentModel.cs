using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestLogic;

namespace InterfaceTestMVC.Models
{
    public class StudentModel
    {
        public string Name { get; set; }
        public string School { get; set; }
        public Student student;
        public StudentModel(Student student)
        {
            Name = student.Name;
            School = student.School;

        }
    }
}
