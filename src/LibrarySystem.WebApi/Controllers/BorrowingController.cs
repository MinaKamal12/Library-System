using LibrarySystem.DataAccess.Entities;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _borrowingService;
        public BorrowingController(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var borrrowing = await _borrowingService.GetAsync(id);
            return Ok(borrrowing);
        }
        [HttpPost]
        public async Task<IActionResult> Add(BorrowingDto borrowingDto)
        {
            var borrowing = await _borrowingService.AddAsync(borrowingDto);
            return Ok(borrowing);

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, BorrowingDto borrowingDto)
        {
            var UpdateBorrowing = await _borrowingService.UpdateAsync(id, borrowingDto);

            if (UpdateBorrowing == null)
            {
                return NotFound();
            }
            return Ok(UpdateBorrowing);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _borrowingService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
