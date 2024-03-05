using Business.Validations;
using Core.Utilities.Tools;
using Microsoft.Extensions.DependencyInjection;
namespace Business;

public class BusinessModule:ICoreModule
{

    public void Load(IServiceCollection services)
    {
        services.AddScoped<ClaimValidations>();
        services.AddScoped<UserValidations>();
        services.AddScoped<AuthValidations>();
        services.AddScoped<ProductValidations>();
        services.AddScoped<OrderValidations>();
        services.AddScoped<CategoryValidations>();
        services.AddScoped<ProductTransacitonValidations>();
    }
}
