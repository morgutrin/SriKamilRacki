using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCrm2.Models
{
    public static class UserContainer
    {
       public static List<User> lista;
        static UserContainer()
        {
            lista = new List<User>();
            lista.Add(new User
            {
                Birthdate = DateTime.Now,
                Id = 1,
                Login = "admin",
                Password = "admin",
                Name = "Kamil",
                Surname = "Racki"
            });
            lista.Add(new User
            {
                Birthdate = DateTime.Now,
                Id = 2,
                Login = "admin1",
                Password = "admin1",
                Name = "Kamil1",
                Surname = "Racki1"
            });
            lista.Add(new User
            {
                Birthdate = DateTime.Now,
                Id = 3,
                Login = "admin3",
                Password = "admin3",
                Name = "Kamil3",
                Surname = "Racki3"
            });
        }
        public static bool UpdateUser(int userToUpdateId, string userBody)
        {
            var userToUpdate = lista.FirstOrDefault(x => x.Id == userToUpdateId);
            if (userToUpdate == null)
            {
                return false;
            }
            var userId = userToUpdate.Id;
            lista.Remove(userToUpdate);
            var userData = JsonConvert.DeserializeObject<User>(userBody);
            userData.Id = userId;
            lista.Add(userData);

            return true;
        }
    }
}