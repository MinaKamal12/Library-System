using LibrarySystem.Domain.Dtos;

namespace LibrarySystem.Domain.Services.Interfaces
{
    public interface IBorrowingService
    {
        Task<BorrowingDto> GetAsync(int id);
        Task<bool> AddAsync(BorrowingDto borrowingDto);
        Task<BorrowingDto> UpdateAsync(int id, BorrowingDto borrowingDto);
        Task<bool> DeleteAsync(int id);
    }
}