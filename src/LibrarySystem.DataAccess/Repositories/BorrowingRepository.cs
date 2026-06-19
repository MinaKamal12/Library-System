using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; // add if needed

namespace LibrarySystem.DataAccess.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly LibraryDBContext _context;
        public BorrowingRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Borrowing borrowing)
        {
            _context.Borrowings.Add(borrowing);
            var result = await _context.SaveChangesAsync();
            return await Task.FromResult(result>0);

        }
        public async Task<Borrowing> GetAsync(int id)
        {
            var result = await (from b in _context.Borrowings
                                where b.Id == id
                                select b).SingleOrDefaultAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var findBorrowing = await _context.Borrowings.FindAsync(id);

            if (findBorrowing == null)
            {
                return false;
            }
            _context.Borrowings.Remove(findBorrowing);
            var result = await _context.SaveChangesAsync();
            return await Task.FromResult(result > 0);

        }
        public async Task<Borrowing> UpdateAsync(int id, Borrowing borrowing)
        {
            var existingBorrowing = await _context.Borrowings.FindAsync(id);
            if (existingBorrowing == null)
            {
                return null;
            }
            existingBorrowing.BorrowPrice = borrowing.BorrowPrice;
            existingBorrowing.BorrowedDate = borrowing.BorrowedDate;
            existingBorrowing.ReturnDate = borrowing.ReturnDate;
            existingBorrowing.UserId = borrowing.UserId;
            existingBorrowing.CopyId = borrowing.Id;
            existingBorrowing.UserName = borrowing.User.Name;
            existingBorrowing.BookName = borrowing.Copy.Book.Name;

            await _context.SaveChangesAsync();

            return existingBorrowing;
    
        }
    }

}
