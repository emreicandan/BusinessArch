using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business;
using Business.DependencyResolver.Autofac;
using Business.Validations;
using Core.DependencyResolver;
using Core.Extensions;
using Core.Utilities.Tools;
using DataAccess.Context;
using DataAccess.DependencyResolver;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Host.ConfigureServices(services =>{
    services.AddDependencyResolvers(new (){ new CoreModule() , new DataAccessModule() , new BusinessModule()});
});

ServiceTool.CreateServiceProvider(builder.Services);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseCors();


var dbContext = ServiceTool.GetService<BusinessDbContext>();
await dbContext.Database.MigrateAsync();
//Code first yazarken migrate ederken update etmeden direkt db'e migrate edecektir.


//var test = ServiceTool.GetService<Test>();
//test.GetAll();


app.Run();
/*
public class Test
{
    private readonly IUserService _userService;

    public Test(IUserService userService)
    {
        _userService = userService;
    }

    public IList<User> GetAll() => _userService.GetAll().ToList();
}*/