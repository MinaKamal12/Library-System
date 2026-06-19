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
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly ICounterRepository _counterRepository;
        public BorrowingService(IBorrowingRepository borrowingRepository, ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;

            _borrowingRepository = borrowingRepository;
        }
        public async Task<bool> AddAsync(BorrowingDto borrowingDto)
        {
            var BorrowingEntity = new Borrowing
            {
                BorrowPrice = borrowingDto.BorrowPrice,
                BorrowedDate = borrowingDto.BorrowedDate,
                ReturnDate = borrowingDto.ReturnDate,
                CopyId = borrowingDto.CopyId,
                UserId = borrowingDto.UserId,
                
            };
            return await _borrowingRepository.AddAsync(BorrowingEntity);

        }

        public async Task<BorrowingDto> GetAsync(int id)
        {
            var borrowing = await _borrowingRepository.GetAsync(id);
            if (borrowing == null)
            {
                return null;
            }
            var borrowingDto = new BorrowingDto
            {
                CopyId = borrowing.CopyId,
                UserId= borrowing.UserId,
                BookName = borrowing.Copy.Book.Name,
                UserName = borrowing.User.Name,
                BorrowedDate= borrowing.BorrowedDate,
                ReturnDate = borrowing.ReturnDate,
                BorrowPrice= borrowing.BorrowPrice
            };

            return borrowingDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var bookDelete = await _borrowingRepository.DeleteAsync(id);
            return bookDelete;

        }
        public async Task<BorrowingDto> UpdateAsync(int id, BorrowingDto borrowingDto)

        {
            var borrowing = new Borrowing
            {
                BorrowedDate = borrowingDto.BorrowedDate,
                ReturnDate = borrowingDto.ReturnDate,
                BorrowPrice = borrowingDto.BorrowPrice,
                CopyId = borrowingDto.CopyId,
                UserId = borrowingDto.UserId,

            };

            var updatedborrowing = await _borrowingRepository.UpdateAsync(id, borrowing);

            if (updatedborrowing == null)
            {
                return null;
            }

            var newBorrowing = new BorrowingDto
            {
                BookName = borrowing.BookName,
                BorrowedDate = borrowing.BorrowedDate,
                BorrowPrice = borrowing.BorrowPrice,
                CopyId = borrowing.CopyId,
                ReturnDate = borrowing.ReturnDate,
                UserId = borrowing.UserId,
                UserName = borrowing.UserName
            };
            return newBorrowing;
        }





    }
}
