using LibrarySystem.DataAccess.Entities;

namespace LibrarySystem.DataAccess.Repositories.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<bool> AddAsync(Borrowing borrowing);
        Task<Borrowing> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Borrowing> UpdateAsync(int id, Borrowing borrowing);
    }
}