using LibrarySystem.Domain.Dtos;

namespace LibrarySystem.Domain.Services.Interfaces
{
    public interface ICopyService
    {
        Task<bool> AddAsync(CopyDto copyDto);
        Task<CopyDto> GetAsync(int id);
        Task<CopyDto> UpdateAsync(int id, CopyDto copyDto);
        Task<bool> DeleteAsync(int id);

    }
}