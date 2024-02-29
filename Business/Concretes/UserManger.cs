using System;
using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Aspect.Autofac.Logging;

namespace Business.Concretes;

public class UserManger : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserValidations _userValidation;

    public UserManger(UserValidations userValidation, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _userValidation = userValidation;
    }

    public User Add(User user)
    {
        return _userRepository.Add(user);
    }

    public async Task<User> AddAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public void DeleteById(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        _userValidation.UserMustNotBeEmpty(user).Wait();
        _userRepository.Delete(user);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        await _userValidation.UserMustNotBeEmpty(user);
        await _userRepository.DeleteAsync(user);
    }

    public IList<User> GetAll()
    {
        return _userRepository.GetAll().ToList();
    }
    [DebugWriteAspect(Message = "Çalıştı")]
    public async Task<IList<User>> GetAllAsync()
    {
        var userList = await _userRepository.GetAllAsync();
        return userList.ToList();
    }

    public IList<User> GetAllByFirstName(string firstName)
    {
        return _userRepository.GetAll(u => u.FirstName == firstName).ToList();
    }

    public IList<User> GetAllByFirstNameContains(string firstName)
    {
        return _userRepository.GetAll(u => u.FirstName.Contains(firstName)).ToList();
    }

    public User? GetById(Guid id)
    {
        return _userRepository.Get(u => u.Id == id);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        
        return await _userRepository.GetAsync(u => u.Id == id);
    }

    public User? GetByUserNameWithClaims(string userName)
    {
        return _userRepository.Get(u => u.UserName == userName,
            include: user=> user.Include(u=>u.UserClaims).ThenInclude(uc=>uc.Claim));
    }

    public async Task<User?> GetByUserNameWithClaimsAsync(string userName)
    {
        return await _userRepository.GetAsync(u => u.UserName == userName,
            include: user => user.Include(u => u.UserClaims).ThenInclude(uc => uc.Claim));
    }

    public User Update(User user)
    {
        return _userRepository.Update(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await _userRepository.UpdateAsync(user);
    }
}

