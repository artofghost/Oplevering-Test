using Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class NotesDal : INoteCollection  , INote
    {
        public MySqlConnection DBConnect()
        {
            string connStr = "server=localhost;user=root;database=dnd;port=3306;password='';SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
        public List<NotesDto> GetAllNotes()
        {
            List<NotesDto> notesDtos = new List<NotesDto>();
            

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
                        notesDtos.Add(new NotesDto
                        {

                            Name = sdr["Name"].ToString(),
                            Id = Convert.ToInt32(sdr["Id"]),
                            Text = sdr["Text"].ToString(),
                            
                           


                        });
                    }
                    conn.Close();
                }

            };
            return notesDtos;

        }

        public NotesDto GetNote(int Id)
        {
            NotesDto noteDto = new NotesDto();
            string query = $"SELECT * FROM `notes` WHERE Id={Id}";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {

                var conn = DBConnect();
                cmd.Connection = conn;
                
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                       
                        noteDto.Name = sdr["Name"].ToString();
                        noteDto.Id = Convert.ToInt32(sdr["Id"]);
                        noteDto.Text = sdr["Text"].ToString();
                    }
                    conn.Close();
                }

            }
            return noteDto;
        }

        public void UpdateNote(NotesDto notesDto)
        {
            string query = $"UPDATE notes SET Name='{notesDto.Name}',Text='{notesDto.Text}' WHERE Id='{notesDto.Id}'";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                
                conn.Close();
                

            };
        }
        public void CreateNote(NotesDto notesDto, int UserId)
        {
            string query = $"INSERT INTO `notes`(`Name`, `Id`, `Text`, `UserId`) VALUES('{notesDto.Name}', '{notesDto.Id}', '{notesDto.Text}', '{UserId}')";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();


            };
        }
        public void DeleteNote(NotesDto notesDto)
        {
            string query = $"Delete FROM notes WHERE Id='{notesDto.Id}'";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();


            };
        }

    }
}
