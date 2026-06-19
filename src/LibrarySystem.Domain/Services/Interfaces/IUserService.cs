using LibrarySystem.Domain.Dtos;

namespace LibrarySystem.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserDto userDto);
        Task<UserDto> GetAsync(int id);
        Task<UserDto> UpdateAsync(int id, UserDto userDto);
        Task<bool> DeleteAsync(int id);

    }
}