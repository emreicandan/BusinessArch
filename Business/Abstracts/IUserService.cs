using System;
using Core.Entities;

namespace Business.Abstracts;

public interface IUserService
{
    User? GetById(Guid id);

    Task<User?> GetByIdAsync(Guid id);

    User? GetByUserNameWithClaims(string userName);

    Task<User?> GetByUserNameWithClaimsAsync(string userName);

    IList<User> GetAll();

    Task<IList<User>> GetAllAsync();

    IList<User> GetAllByFirstName(string firstName);

    IList<User> GetAllByFirstNameContains(string firstName);

    User Add(User user);

    User Update(User user);

    void DeleteById(Guid id);

    Task<User> AddAsync(User user);

    Task<User> UpdateAsync(User user);

    Task DeleteByIdAsync(Guid id);
}

