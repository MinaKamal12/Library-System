using LibrarySystem.DataAccess.Entities;

namespace LibrarySystem.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User user);
        Task<User> GetAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<User> UpdateAsync(int id, User updatedUser);
    }
}