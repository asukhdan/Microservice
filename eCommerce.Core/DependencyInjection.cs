using System;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContract;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreService(this IServiceCollection service)
    {
       service.AddTransient<IUserService,UserService>();
       service.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
       return service;
    } 

}
