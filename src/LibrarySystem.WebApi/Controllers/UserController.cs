using LibrarySystem.Domain.Dtos;
using LibrarySystem.Domain.Services;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            var addUser = await _userService.AddAsync(userDto);
            return Ok(addUser);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var getUser = await _userService.GetAsync(id);
            return Ok(getUser);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            var UpdateUser = await _userService.UpdateAsync(id, userDto);

            if (UpdateUser == null)
            {
                return NotFound();
            }
            return Ok(UpdateUser);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
