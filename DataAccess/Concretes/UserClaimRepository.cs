using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes
{
    public class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
    {
        public UserClaimRepository(BusinessDbContext context) : base(context)
        {
        }
    }
}

