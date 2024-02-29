using System;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Tools;

public static class ServiceTool // IoC containere httpContext harici erişebileceğimiz 2. bir kanal oluşturduk.
{
    public static IServiceProvider ServiceProvider { get; set; }

    public static void CreateServiceProvider(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
    }

    public static T GetService<T>() => ServiceProvider.GetService<T>() ?? throw new Exception("Service not found");
}