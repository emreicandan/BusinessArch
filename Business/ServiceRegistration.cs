using System;
using Business.Abstracts;
using Business.Concretes;
using Business.Validations;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
	public static class ServiceRegistration
	{
		public static void RegisterBusinessService(this IServiceCollection services)
		{

			services.AddDbContext<BusinessDbContext>();
            services.AddSingleton<ITokenHelper, JWTTokenHelper>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<ClaimValidations>();
            services.AddScoped<IClaimService, ClaimMenager>();
            services.AddScoped<IUserClaimRepository, UserClaimRepository>();
			services.AddScoped<UserValidations>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserManger>();
            services.AddScoped<AuthValidations>();
            services.AddScoped<IAuthService, AuthMenager>();
        }
	}
}

