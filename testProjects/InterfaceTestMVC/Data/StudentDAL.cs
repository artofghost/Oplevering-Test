using ContractInteface;
using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Data
{
    public class StudentDAL : IStudent
    {
        public MySqlConnection DBConnect()
        {
            string connStr = "server=localhost;user=root;database=dnd;port=3306;password='';SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
        public List<StudentDTO> GetAllStudents()
        {
            List<StudentDTO> studentDTOs = new List<StudentDTO>();


            string query = "SELECT * FROM `student`";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        studentDTOs.Add(new StudentDTO
                        {

                            Name = sdr["Name"].ToString(),
                            School = sdr["School"].ToString()

                        });
                    }
                    conn.Close();
                }
            };
            return studentDTOs;
        }
    }
}
