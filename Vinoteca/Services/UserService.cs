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
    
            _userRepository.Create(dto);

        }

        public GetUserByIdDto GetOneUser(int id)
        {
            return _userRepository.GetOneUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetUsersList();
        }

        public void RemoveOneUser(int id)
        {
             _userRepository.removeUser(id);
        }
    }


}
