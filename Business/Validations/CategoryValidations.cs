using System;
using Business.Tools.Exceptions;
using Core.Entities;
using Entities.Models;

namespace Business.Validations;

public class CategoryValidations
{
    public async Task CheckCategoryName(Category category)
    {
        IList<string> blackList = new List<string>()
        {
             "allah",
            "kuran",
            "peygamber",
            "hz",
            "atatürk"
        };
        foreach (string name in blackList)
        {
            if (category.Name.ToLower().Contains(name))
            {
                throw new ValidationException($"User name cannot be {name}");
            }
        }
        await Task.CompletedTask;
    }

    public async Task CategoryMustNotBeEmpty(Category? category)
    {
        if(category == null)
        {
            throw new ValidationException("Category must not be empty");
        }

        await Task.CompletedTask;
    }

}

