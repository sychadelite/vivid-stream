using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vivid.Data.Interfaces;
using Vivid.Models;

namespace Vivid.Repository
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
               new User() { Id = 1, Name = "Ali", Email = "ali@gmail.com", Bio = "Morocco"},
               new User() { Id = 2, Name = "Amine", Email = "amine@gmail.com", Bio = "Morocco"},
               new User() { Id = 3, Name = "Kumar", Email = "kumar@gmail.com", Bio = "India"},
               new User() { Id = 4, Name = "Messi", Email = "messi@gmail.com", Bio = "Spain"},
            };

            return users;
        }
    }
}