using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LibrarySystem.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDBContext _context;
        public UserRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();

            return await Task.FromResult(result > 0);

        }
        public async Task<User> GetAsync(int id)
        {
            //var result = await (from user in _context.Users
            //                    where user.Id == id
            //                    select user).SingleOrDefaultAsync();

            var user = await _context.Users.FindAsync(id);

            return user;

        }
        public async Task<bool> DeleteAsync(int id)
        {
            var findUser = await _context.Users.FindAsync(id);

            if (findUser == null)
            {
                return false;
            }

            _context.Users.Remove(findUser);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<User> UpdateAsync(int id, User updatedUser)
        {
            var existingUsere = await _context.Users.FindAsync(id);

            if (existingUsere == null)
            {
                return null;
            }

            existingUsere.Name = updatedUser.Name;
            existingUsere.Email = updatedUser.Email;
            existingUsere.PhoneNumber = updatedUser.PhoneNumber;
            existingUsere.Balance = updatedUser.Balance;

            await _context.SaveChangesAsync();

            return existingUsere;
        }


    }
}
