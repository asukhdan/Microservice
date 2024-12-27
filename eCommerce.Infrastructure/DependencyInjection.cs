using System;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add Infrastructure service to the dependency injection container
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructureService(this IServiceCollection service)
    {
       //To Do Add services to the IoC Container
       //Infrastructure services often include  data access, casing and other low level components
        service.AddSingleton<IUserRepository, UserRepository>();
        service.AddTransient<DapperDbContext>();
        return service;
    }

}
