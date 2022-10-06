using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Function.Account.Commands.CreateAccount;
using Services.Function.Account.Queries;

namespace MovieAPI.Presentations.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("async/register", Name = "CreateAccount")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RegisterUser([FromBody] CreatedAccountCommand account)
        {
            var result = await _mediator.Send(account);
            
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.AccountId);
        }

        [HttpPost("async/login", Name = "Login")]
        public async Task<ActionResult> Login([FromBody] LoginQuery login)
        {
            var result = await _mediator.Send(login);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result.Token);
        }
    }
}
