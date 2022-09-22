using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Function.Account.Commands.CreateAccount;

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

            return Ok(result.AccountId); ;
        }
    }
}
