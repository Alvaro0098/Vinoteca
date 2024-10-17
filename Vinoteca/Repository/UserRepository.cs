using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System.Data;
using Vinoteca.Data;
using Vinoteca.Entities;
using Vinoteca.Models.Dtos;
using Vinoteca.Repository.interfaces;

namespace Vinoteca.Repository
{
    public class UserRepository : IUserRepository
    {
        private VinotecaContext _context;

        public UserRepository(VinotecaContext context)
        {
            _context = context;
        }

        public List<User> GetUsersList()
        {
            return _context.Users.ToList();
        }

        public void Create(CreateAndUpdateUserDto dto)
        {
            User newUser = new User()
            {
                UserName = dto.UserName,
                Password = dto.Password,
       
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public GetUserByIdDto? GetOneUserById(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.id == userId);
            if (user is not null)
            {
                return new GetUserByIdDto()
                {
                    UserName = user.UserName,
                };
            }
            return null;
        }

        public void removeUser(int userId)
        {
            var user = _context.Users.SingleOrDefault(u => u.id == userId);
            if (user is null)
            {
                throw new Exception("El cliente que intenta eliminar no existe");
            }

            if (user.UserName != "Admin")
            {
                Delete(userId);
            }

        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.id == id));
            _context.SaveChanges();
        }


    }
}
