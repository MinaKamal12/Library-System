using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Domain.Services
{
    public class CopyService : ICopyService
    {
        private readonly ICopyRepository _copyRepository;
        private readonly ICounterRepository _counterRepository;

        public CopyService(ICopyRepository copyRepository, ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
            _copyRepository = copyRepository;
        }

        public async Task<bool> AddAsync(CopyDto copyDto)
        {
            var copyEntity = new Copy
            {
                BookId = copyDto.BookId,
                NumberOfCopies = copyDto.NumberOfCopies,
                Status = copyDto.Status
            };

            return await _copyRepository.AddAsync(copyEntity);
        }

        public async Task<CopyDto> GetAsync(int id)
        {
            var copy = await _copyRepository.GetAsync(id);
            if (copy == null) 
            {
                return null;
            }

            var copyDto = new CopyDto
            {
                BookId = copy.BookId,
                BookName = copy.Book.Name,
                NumberOfCopies=copy.NumberOfCopies,
                Status=copy.Status
            };
            return copyDto;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var copyDelete = await _copyRepository.DeleteAsync(id);
            return copyDelete;

        }
        public async Task<CopyDto> UpdateAsync(int id, CopyDto copyDto)

        {
            var copy = new Copy
            {
                BookId=copyDto.BookId,
                NumberOfCopies= copyDto.NumberOfCopies,
                Status= copyDto.Status

            };

            var updatedCopy = await _copyRepository.UpdateAsync(id, copy);

            if (updatedCopy == null)
            {
                return null;
            }

            var newCopy = new CopyDto
            {
                BookId = updatedCopy.BookId,
                BookName = updatedCopy.Book.Name,
                NumberOfCopies = updatedCopy.NumberOfCopies,
                Status = updatedCopy.Status
            };
            return newCopy;
        }

    }
}
