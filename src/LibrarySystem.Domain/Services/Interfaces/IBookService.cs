using LibrarySystem.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Services.Interfaces
{
    public interface IBookService 
    {
        Task<BookDto> GetAsync(int id);
        Task<bool> AddAsync(BookDto book);
        Task<BookDto?> UpdateAsync(int id, BookDto bookDto);
        Task<bool> DeleteAsync(int id);
    }
}
