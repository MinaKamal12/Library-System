using LibrarySystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LibrarySystem.DataAccess.Repositories
{
    public class CopyRepository : ICopyRepository
    {
        public readonly LibraryDBContext _context;
        public CopyRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Copy copy)
        {
            _context.Copies.Add(copy);
            var result = await _context.SaveChangesAsync();
            return await Task.FromResult(result > 0);
        }


        public async Task<Copy> GetAsync(int id)
        {
            var result = await (from c in _context.Copies
                                where c.Id == id
                                select c).SingleOrDefaultAsync();
            return result;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var FindCopy = await _context.Copies.FindAsync(id);

            if (FindCopy == null)
            {
                return false;
            }

            _context.Copies.Remove(FindCopy);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Copy> UpdateAsync(int id, Copy updatedCopy)
        {
            var existingCopy= await _context.Copies.FindAsync(id);

            if (existingCopy == null)
            {
                return null;
            }

            existingCopy.NumberOfCopies = updatedCopy.NumberOfCopies;
            existingCopy.Status = updatedCopy.Status;
            existingCopy.BookId = updatedCopy.BookId;

            await _context.SaveChangesAsync();

            return existingCopy;
        }




    }
}
