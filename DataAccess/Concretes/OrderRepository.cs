using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(BusinessDbContext context) : base(context)
    {
    }
}

