using System.Threading.Tasks;
using AccountManager.Application;
using AccountManager.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Fields

        private readonly IUserService userService;

        #endregion

        #region Constructor

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await userService.GetAllUsersAsync());
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await userService.GetUserAsync(email);

            if (user == null)
            {
                return NotFound($"User with email {email} is not found");
            }

            return Ok(user);
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ValidationState);
            }

            await userService.AddUserAsync(request);
            return Ok();

        }

        #endregion
    }
}