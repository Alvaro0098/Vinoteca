using Microsoft.AspNetCore.Http.HttpResults;
using Vinoteca.Entities;
using Vinoteca.Repository.interfaces;

namespace Vinoteca.Repository
{
    public class UserRepository : IUserRepository
    {
        public static List<User> users = new List<User>();



        public List<User> GetUsersList()
        {
            return users.ToList();
        }

        public void addUser(User user)
        {
            users.Add(user);
        }


        public User GetOneUser(int id)
        {
            var userId = users.FirstOrDefault(u => u.id == id);

            if (userId == null)
            {
                return null;
            }

            return userId;
        }

        public bool removeUser(int id)
        {
            var userToRemove = users.FirstOrDefault(u => u.id == id);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                return true;
            }

            return false;
        }
    }
}
