using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BusinessDbContext context) : base(context)
        {
        }
    }
}

