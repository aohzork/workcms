using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/v1.0/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a single User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        /// <summary>
        /// Create a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO user)
        {
            await _userService.CreateUserAsync(user);
            return Ok();
        }

        /// <summary>
        /// Change a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        /// <summary>
        /// Delete a user with soft delete
        /// </summary>
        /// <param name="id"></param>
        [HttpPut("deleteUser{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
        /// <summary>
        /// Check if user name is avaliable
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("checkUser/{userName}")]
        public async Task<IActionResult> CheckUserNameAvalibility (string userName)
        {
            var isAvaliable = await _userService.IsUserNameAvaliableAsync(userName);
            return Ok(isAvaliable);
        }
    }
}
