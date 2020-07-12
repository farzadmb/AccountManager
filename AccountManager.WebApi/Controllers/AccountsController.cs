using System;
using System.Threading.Tasks;
using AccountManager.Application;
using AccountManager.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace AccountManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region Fields

        private readonly IAccountService accountService;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        /// <param name="accountService">
        /// The account service
        /// </param>
        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        #endregion

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await this.accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet]
        [Route("users/{userId}")]
        public async Task<IActionResult> GetUserAccounts(int userId)
        {
            var accounts = await this.accountService.GetUserAccounts(userId);
            return Ok(accounts);
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<IActionResult> AddAccount(AddAccountRequest request)
        {
            try
            {
                await this.accountService.AddAccountAsync(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion
    }
}
