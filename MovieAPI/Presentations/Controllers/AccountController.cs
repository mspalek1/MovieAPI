using Microsoft.AspNetCore.Mvc;
using Models;

namespace MovieAPI.Presentations.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        //private readonly IAccountService _accountService;

        //public AccountController(IAccountService accountService)
        //{
        //    _accountService = accountService;
        //}

        //[HttpPost("register")]
        //public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        //{
        //    _accountService.RegisterUser(dto);
        //    return Ok();
        //}
    }
}
