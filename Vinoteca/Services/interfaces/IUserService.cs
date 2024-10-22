using Vinoteca.Entities;
using Vinoteca.Models.Dtos;

namespace Vinoteca.Services.interfaces
{
    public interface IUserService
    {
       void AddOneUser(CreateAndUpdateUserDto dto);

       public List<User> GetAllUsers();

      GetUserByIdDto GetOneUser(int id);

      public void RemoveOneUser(int id);
    }
}
