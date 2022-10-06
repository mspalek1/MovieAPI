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

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (resource.CreatedById == int.Parse(userId))
            {
                context.Succeed(requirement);
            }
            
            return Task.CompletedTask;
        }
    }
}
