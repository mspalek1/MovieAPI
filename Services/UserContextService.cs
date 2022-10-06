using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Services.Interfaces;

namespace Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public int? GetUserId
        {
            get
            {

                int? userId = null;
                var climeType = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                if (climeType != null)
                {
                    userId = int.Parse(climeType.Value);
                }   

                return userId;
            }

        }
    }
}