using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Core.Entities;


namespace DataAccess.Concretes;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(BusinessDbContext context) : base(context)
    {
    }
}

