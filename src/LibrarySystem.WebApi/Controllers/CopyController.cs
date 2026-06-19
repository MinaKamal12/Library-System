using LibrarySystem.DataAccess.Entities;
using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CopyController : ControllerBase
    {

        private readonly ICopyService _copyService;
        public CopyController(ICopyService copyService)
        {
            _copyService = copyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var copy = await _copyService.GetAsync(id);
            return Ok(copy);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CopyDto copyDto)
        {
            var addCopy = await _copyService.AddAsync(copyDto);
            return Ok(addCopy);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, CopyDto copyDto)
        {
            var UpdateCopy = await _copyService.UpdateAsync(id, copyDto);

            if (UpdateCopy == null)
            {
                return NotFound();
            }
            return Ok(UpdateCopy);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _copyService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

  

    }
}

