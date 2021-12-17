using Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CharacterDal : ICharacters , ICharacterCollection
    {
        public MySqlConnection DBConnect()
        {
            string connStr = "server=localhost;user=root;database=dnd;port=3306;password='';SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
        /// <summary>
        /// This shows gets all the characters from the DB
        /// </summary>
        /// <returns>
        /// All the characters
        /// </returns>
        public List<CharacterDto> GetAllCharacters()
        {
            List<CharacterDto> characterDtos = new List<CharacterDto>();
           

            string query = "SELECT * FROM `character_dnd`";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        characterDtos.Add(new CharacterDto
                        {

                            Name = sdr["Name"].ToString(),
                            Id = Convert.ToInt32(sdr["Id"]),
                            Icon = sdr["Icon"].ToString(),
                            Colour = sdr["Colour"].ToString(),
                            Class = sdr["Class"].ToString(),
                            Race = sdr["Race"].ToString()

                        });
                    }
                    conn.Close();
                }
            };
            return characterDtos;
        }
        public CharacterDto GetCharacter(int Id)
        {
            CharacterDto characterDto = new CharacterDto();
            string query = $"SELECT * FROM `character_dnd` WHERE Id={Id}";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        characterDto.Id = Convert.ToInt32(sdr["Id"]);
                        characterDto.Name = sdr["Name"].ToString();                        
                        characterDto.Icon = sdr["Icon"].ToString();
                        characterDto.Colour = sdr["Colour"].ToString();
                        characterDto.Class = sdr["Class"].ToString();
                        characterDto.Race = sdr["Race"].ToString();
                    }
                    conn.Close();
                }

            }
            return characterDto;
        }

        public void UpdateCharacter(CharacterDto characterDto)
        {
            string query = $"UPDATE character_dnd SET Name='{characterDto.Name}',Icon='{characterDto.Icon}',Colour='{characterDto.Colour}',Class='{characterDto.Class}',Race='{characterDto.Race}' WHERE Id='{characterDto.Id}'";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();


            };
        }
        public void CreateCharacter(CharacterDto characterDto, int UserId)
        {
            string query = $"INSERT INTO `character_dnd`(`Name`, `Id`, `Icon`, `Colour`, `Class`, `Race`, `UserId`) VALUES ('{characterDto.Name}','{characterDto.Id}','{characterDto.Icon}','{characterDto.Colour}','{characterDto.Class}','{characterDto.Race}', {UserId})";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();


            };
        }
        public void DeleteCharacter(CharacterDto characterDto)
        {
            string query = $"Delete FROM character_dnd WHERE Id='{characterDto.Id}'";
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
