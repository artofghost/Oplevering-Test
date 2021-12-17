using ContractInteface;
using Data;
using System;


namespace Factory
{
    public class StudentFactory
    {
        public  IStudent Student()
        {
            IStudent student = new StudentDAL();
            return student;
        }
    }
}