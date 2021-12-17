using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data
{
    public class DAL
    {

        public MySqlConnection DBConnect()
        {
            string connStr = "server=localhost;user=root;database=student;port=3306;password='';SslMode=none";
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
        public string AddStudent(StudentDTO studentDTO)
        {
            try
            {
                string query = "INSERT INTO `student`(`Name`, `School`) VALUES (@Name, @School)";

                MySqlCommand cmd = new MySqlCommand(query);
                var conn = DBConnect();
                conn.Open();
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("Name", studentDTO.Name);
                cmd.Parameters.AddWithValue("School", studentDTO.School);
                
                cmd.ExecuteNonQuery();
                conn.Close();
                return ("Character Added Succesfully");
            }
            catch (Exception ex)
            {
                if (DBConnect().State == ConnectionState.Open)
                {
                    DBConnect().Close();
                }
                return (ex.Message.ToString());
            }
        }

    }
}
