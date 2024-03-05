using System;
using System.Diagnostics;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Custom.Microsoft;
using Core.Utilities.Security.JWT;
using Core.Utilities.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolver;

	public class CoreModule:ICoreModule
	{

    public void Load(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, MicrosoftCacheMenager>();
        services.AddSingleton<ITokenHelper, JWTTokenHelper>();
        services.AddSingleton<Stopwatch>();
    }
}


