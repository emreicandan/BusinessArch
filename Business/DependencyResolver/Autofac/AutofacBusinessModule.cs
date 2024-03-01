using System;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Custom;
using Core.Utilities.Interceptor;
using Module = Autofac.Module;

namespace Business.DependencyResolver.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CustomCacheMenager>().As<ICacheService>();
        builder.RegisterType<ClaimMenager>().As<IClaimService>();
        builder.RegisterType<UserManger>().As<IUserService>();
        builder.RegisterType<AuthMenager>().As<IAuthService>();

        var assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }

}

