using System.Reflection;
using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Validators;
using Persistence.Repositories;
using Services.Function.Movie.Commands;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.AddScoped<IValidator<MovieQuery>, MovieQueryValidator>();

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
