using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICounterRepository _counterRepository;
        public UserService(IUserRepository userRepository, ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> AddAsync(UserDto userDto)
        {
            var userEntity = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Balance = userDto.Balance,

            };
            return await _userRepository.AddAsync(userEntity);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return null;
            }
            var userDto = new UserDto { 
            Name = user.Name,
            Email= user.Email,
            PhoneNumber= user.PhoneNumber,
            Balance= user.Balance,

            };
            return userDto; 
            
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _userRepository.DeleteAsync(id);

        }
        public async Task<UserDto> UpdateAsync(int id, UserDto userDto)

        {
            var user = new User
            {
                Name= userDto.Name,
                Email=userDto.Email,
                PhoneNumber=userDto.PhoneNumber,
                Balance = userDto.Balance
            };

            var updatedUser= await _userRepository.UpdateAsync(id, user);

            if (updatedUser == null)
            {
                return null;
            }

            var newUser = new UserDto
            {

                Name = updatedUser.Name,
                Email = updatedUser.Email,
                PhoneNumber = updatedUser.PhoneNumber,
                Balance = updatedUser.Balance

            };

            return newUser;
             
        }





    }
}
