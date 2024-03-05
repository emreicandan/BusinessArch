using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BusinessDbContext context) : base(context)
        {
        }
    }
}

