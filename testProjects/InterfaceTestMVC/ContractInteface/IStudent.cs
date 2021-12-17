using DTO;
using System;
using System.Collections.Generic;

namespace ContractInteface
{
    public interface IStudent
    {
        public List<StudentDTO> GetAllStudents();

    }
}
