using Domain.Queries;
using Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Validators;
using Persistence.Repositories;
using Services.Interfaces;
using Services.Services;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddScoped<IValidator<CreateMovieDto>, CreateMovieDtoValidator>();
            services.AddScoped<IValidator<MovieQuery>, MovieQueryValidator>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}
