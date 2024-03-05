using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class ProductTransactionRepository : Repository<ProductTransaction>, IProductTransactionRepository
{
    public ProductTransactionRepository(BusinessDbContext context) : base(context)
    {
    }
}

