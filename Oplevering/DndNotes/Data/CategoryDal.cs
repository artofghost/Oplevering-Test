using Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CategoryDal : ICategory , ICategoryCollection
    {
        public MySqlConnection DBConnect()
        {
            string connStr = "server=localhost;user=root;database=dnd;port=3306;password='';SslMode=none";
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }
    
     
        public List<CategoryDto> GetAllCategorys()
        {
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            

            string query = "SELECT * FROM `category`";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        categoryDtos.Add(new CategoryDto
                        {

                            Name = sdr["Name"].ToString(),
                            Id = Convert.ToInt32(sdr["Id"]),
                            Icon = sdr["Icon"].ToString(),
                            Colour = sdr["Colour"].ToString()
                            

                        });
                    }
                    conn.Close();
                }
            };
            return categoryDtos;
        }
        public CategoryDto GetCategory(int Id)
        {
            CategoryDto categoryDto = new CategoryDto();
            string query = $"SELECT * FROM `category` WHERE Id={Id}";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        categoryDto.Name = sdr["Name"].ToString();
                        categoryDto.Id = Convert.ToInt32(sdr["Id"]);
                        categoryDto.Icon = sdr["Icon"].ToString();
                        categoryDto.Colour = sdr["Colour"].ToString();
                    }
                    conn.Close();
                }

            }
            return categoryDto;
        }
        public void UpdateCategory(CategoryDto categoryDto)
        {
            string query = $"UPDATE `category` SET `Name`='{categoryDto.Name}',`Icon`='{categoryDto.Icon}',`Colour`='{categoryDto.Colour}' WHERE `Id`='{categoryDto.Id}'";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();


            };
        }
        public void CreateCategory(CategoryDto categoryDto, int UserId)
        {
            string query = $"INSERT INTO `category`(`Name`, `Id`, `Icon`, `Colour`, `UserId`) VALUES ('{categoryDto.Name}','{categoryDto.Id}','{categoryDto.Icon}','{categoryDto.Colour}','{UserId}')";
            using (MySqlCommand cmd = new MySqlCommand(query))
            {
                var conn = DBConnect();
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();


            };
        }
        public void DeleteCategory(CategoryDto categoryDto)
        {
            string query = $"Delete FROM category WHERE Id='{categoryDto.Id}'";
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
