using Models;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
}
