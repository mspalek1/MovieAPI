using System.Reflection;
using Domain.Entities;
using Domain.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models.Validators;
using Services.Authorization;
using Services.Interfaces;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddScoped<IValidator<MovieQuery>, MovieQueryValidator>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
            services.AddScoped<IUserContextService, UserContextService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
