using FluentValidation.Results;

namespace Services.Function.Account.Commands.CreateAccount
{
    public class CreatedAccountCommandResponse : BaseResponse
    {
        public int AccountId { get; set; }
        public CreatedAccountCommandResponse() : base()
        {
        }

        public CreatedAccountCommandResponse(int accountId) : base()
        {
            AccountId = accountId;
        }

        public CreatedAccountCommandResponse(string message = null) : base(message)
        {
        }

        public CreatedAccountCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreatedAccountCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }
    }
}
