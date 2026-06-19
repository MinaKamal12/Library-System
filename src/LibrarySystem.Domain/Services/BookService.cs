using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICounterRepository _counterRepository;

        public BookService(IBookRepository bookRepository, ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
            _bookRepository = bookRepository;
            
        }

        public async Task<bool> AddAsync(BookDto bookDto)
        {
            var bookEntity = new Book
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Price = bookDto.Price,
            };

            return await _bookRepository.AddAsync(bookEntity);


        }

        public async Task<BookDto> GetAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);

            if (book == null)
            {
                return null;
            }
            var bookDto = new BookDto
            {
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };

            return bookDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var bookDelete = await _bookRepository.DeleteAsync(id);
            return bookDelete;

        }
        public async Task<BookDto> UpdateAsync(int id, BookDto bookDto)

        {
            var book = new Book
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Description = bookDto.Description,
                Price = bookDto.Price
            };

            var updatedBook = await _bookRepository.UpdateAsync(id, book);

            if (updatedBook == null)
            {
                return null;
            }

            var NewBook =new BookDto
            {
                Name = updatedBook.Name,
                Author = updatedBook.Author,
                Price = updatedBook.Price,
                Description = updatedBook.Description,
            };
            return NewBook;
        }


    }
}

