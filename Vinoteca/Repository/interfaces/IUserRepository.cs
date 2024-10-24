﻿using Vinoteca.Entities;
using Vinoteca.Models.Dtos;

namespace Vinoteca.Repository.interfaces
{
    public interface IUserRepository
    {
        public List<User> GetUsersList();

        public User? Authenticate(string username, string password); 
     
        void Create(CreateAndUpdateUserDto userDto);

        GetUserByIdDto GetOneUserById(int userId);

        void removeUser(int id);

        void Delete(int id);
    }
}
