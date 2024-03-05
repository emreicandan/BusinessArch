using System;
using Business.Tools.Exceptions;
using Core.Entities;


namespace Business.Validations;

public class UserValidations
{
    public async Task UserMustNotBeEmpty(User? user)
    {
        if (user == null)
        {
            throw new ValidationException("User must not be empty.", 400);
        }
        await Task.CompletedTask;
    }

    public async Task CheckUserName(User user)
    {
        IList<string> BlackList = new List<string>()
        {
             "allah",
            "kuran",
            "peygamber",
            "hz",
            "atatürk"
        };
        foreach(string name in BlackList)
        {
            if (user.UserName.ToLower().Contains(name))
            {
                throw new ValidationException($"User name cannot be {name}");
            }
        }
        await Task.CompletedTask;
    }
    public async Task CheckFirstName(User user)
    {
        IList<string> BlackList = new List<string>()
        {
            "allah",
            "kuran",
            "peygamber",
            "hz",
            "atatürk"
        };
        foreach (string name in BlackList)
        {
            if (user.FirstName.ToLower().Contains(name))
            {
                throw new ValidationException($"User name cannot be {name}");
            }
        }
        await Task.CompletedTask;
    }
    public async Task CheckLastName(User user)
    {
        IList<string> BlackList = new List<string>()
        {
            "allah",
            "kuran",
            "peygamber",
            "hz",
            "atatürk"
        };
        foreach (string name in BlackList)
        {
            if (user.LastName.ToLower().Contains(name))
            {
                throw new ValidationException($"User name cannot be {name}");
            }
        }
        await Task.CompletedTask;
    }
}

