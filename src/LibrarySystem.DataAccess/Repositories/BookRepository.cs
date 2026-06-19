using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace LibrarySystem.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDBContext _context;
        public BookRepository(LibraryDBContext context) 
        {
            _context = context;

        }
        public async Task<bool> AddAsync(Book book)
        {
           // book.CreatedDate = DateTime.Now;
            _context.Books.Add(book);
            
            var result = await _context.SaveChangesAsync();
            return await Task.FromResult(result > 0);
            
        }

        public async Task<Book> GetAsync(int id)
        {
            var result = await (from b in _context.Books
                          where b.Id == id
                          select b ).SingleOrDefaultAsync();
                          
                          
            return  result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Findbook = await _context.Books.FindAsync(id);

            if (Findbook == null)
            {
                return false;
            }

            _context.Books.Remove(Findbook);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Book> UpdateAsync(int id, Book updatedBook)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.Name = updatedBook.Name;
            existingBook.Author = updatedBook.Author;
            existingBook.Description = updatedBook.Description;
            existingBook.Price = updatedBook.Price;

            await _context.SaveChangesAsync();

            return existingBook;
        }

        public async Task<List<Book>> Get(string authorName )
        {
            var books = await (from b in _context.Books
                                     where b.Author == authorName
                                     select b).ToListAsync();

            return books;

            // select * from book 
            // where author = " "


        } 
     


    }
    
}
