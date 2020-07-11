using System.Threading.Tasks;
using AccountManager.Application;
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

        #endregion
    }
}
