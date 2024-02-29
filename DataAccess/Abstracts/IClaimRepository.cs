using System;
using Core.Repository;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IClaimRepository : IAsyncRepository<Claim>, IRepository<Claim>
{
}

