using Data;
using DTO;
using System;

namespace TestLogic
{
    public class Student
    {
        public string Name { get; set; }
        public string School { get; set; }
        StudentDAL dal = new StudentDAL();


        public Student(StudentDTO studentDTO)
        {
            Name = studentDTO.Name;
            School = studentDTO.School;
        }
    }
}
