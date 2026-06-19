using LibrarySystem.DataAccess.Entities;

namespace LibrarySystem.DataAccess.Repositories.Interfaces
{
    public interface ICopyRepository
    {
        Task<bool> AddAsync(Copy copy);
        Task<Copy> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Copy> UpdateAsync(int id, Copy updatedCopy);
    }
}