using System;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class ClaimRepository : Repository<Claim>, IClaimRepository
{
    public ClaimRepository(BusinessDbContext context) : base(context)
    {
    }
}

