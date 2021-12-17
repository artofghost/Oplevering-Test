using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace DndNotes.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;

        }
        public UserModel()
        {

        }
    }
}
