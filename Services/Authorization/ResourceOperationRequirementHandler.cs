using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Services.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Movie>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement,
            Movie resource)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read ||
                requirement.ResourceOperation == ResourceOperation.Create)
            {
                context.Succeed(requirement);
            }

            int userId = 0;

            var climeType = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
            if (climeType != null)
            {
                userId = int.Parse(climeType.Value);
            }

            if (resource.CreatedById == userId)
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}