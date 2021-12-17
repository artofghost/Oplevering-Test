using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class NotesDAL
    {
        public MySqlConnection DBConnect()
        {
            string connStr = "server=localhost;user=root;database=dnd;port=3306;password='';SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
        public List<NotesDTO> GetAllNotes()
        {
            List<NotesDTO> NotesDTOs = new List<NotesDTO>();


            string query = "SELECT * FROM `notes`";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        NotesDTOs.Add(new NotesDTO
                        {

                            Name = sdr["Name"].ToString(),
                            Id = Convert.ToInt32(sdr["Id"]),
                            Text = sdr["Text"].ToString(),




                        });
                    }
                    conn.Close();
                }
            };
            return NotesDTOs;
        }
    }
}
