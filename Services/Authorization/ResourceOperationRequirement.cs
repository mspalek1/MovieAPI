using Domain.Data;
using Microsoft.AspNetCore.Authorization;

namespace Services.Authorization
{
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperation ResourceOperation { get;}
        public ResourceOperationRequirement(ResourceOperation resourceOperation)
        {
            ResourceOperation = resourceOperation;
        }
    }
}
