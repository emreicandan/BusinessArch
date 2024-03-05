using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(BusinessDbContext context) : base(context)
        {
        }
    }
}

