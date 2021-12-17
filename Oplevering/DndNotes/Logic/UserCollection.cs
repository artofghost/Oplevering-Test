using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace Logic
{
    public class UserCollection
    {
        public List<User> users = new List<User>();
        private IUserCollection user;



        public UserCollection()
        {
            user = UserFactory.CreateUserCollectionFactory();

            foreach (var userDto in user.GetAllUsers())
            {
                users.Add(new User(userDto));
            }
        }
     
    }
}
