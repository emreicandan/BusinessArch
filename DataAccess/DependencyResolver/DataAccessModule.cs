using System;
using Core.Utilities.Tools;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyResolver;

public class DataAccessModule:ICoreModule
{

    void ICoreModule.Load(IServiceCollection services)
    {
        services.AddDbContext<BusinessDbContext>();
        services.AddScoped<IUserClaimRepository, UserClaimRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClaimRepository, ClaimRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductTransactionRepository, ProductTransactionRepository>();
    }
}
