using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository.interfaces;
using Vinoteca.Services.interfaces;

namespace Vinoteca.Services
{

    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddOneUser(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                userName = dto.userName,
                lastName = dto.lastName
            };
            _userRepository.addUser(newUser);

        }

        public User? GetOneUserId(int id)
        {
            return _userRepository.GetOneUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetUsersList();
        }

        public bool RemoveOneUser(int id)
        {
            return _userRepository.removeUser(id);
        }
    }


}
