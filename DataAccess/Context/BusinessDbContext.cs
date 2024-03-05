using System;
using Core.Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class BusinessDbContext:DbContext
{
	public BusinessDbContext()
	{
	}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=BusinessSimple;User Id=SA;TrustServerCertificate=true;Password=reallyStrongPwd123;");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<UserClaim> UserClaims { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductTransaction> ProductTransactions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}

