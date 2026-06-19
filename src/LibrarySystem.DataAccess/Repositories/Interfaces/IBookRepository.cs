using LibrarySystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DataAccess.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddAsync(Book book);
        Task<Book> GetAsync(int id);
        Task<Book?> UpdateAsync(int id, Book updatedBook);
        Task<bool> DeleteAsync(int id);
    }
}