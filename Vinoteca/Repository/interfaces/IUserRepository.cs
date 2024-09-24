using Vinoteca.Entities;

namespace Vinoteca.Repository.interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsersList();

        User? GetOneUser(int id);
        void addUser(User user);

        bool removeUser(int id);
    }
}
