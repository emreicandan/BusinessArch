using System;
using Business.Tools.Exceptions;
using Entities.Models;

namespace Business.Validations;

public class ProductValidations
{
    public async Task ProductMustNotBeEmpty(Product? product)
    {
        if(product == null)
        {
            throw new ValidationException("Product must not be empty");
        }

        await Task.CompletedTask;
    }

    public async Task CheckProductName(Product product)
    {
        IList<string> blackList = new List<string>()
        {
            "allah",
            "kuran",
            "peygamber",
            "hz",
            "atatürk"
        };

        foreach(string name in blackList)
        {
            if (product.Name.ToLower().Contains(name))
            {
                throw new ValidationException($"Product name cannot be {name}");
            }
        }
        await Task.CompletedTask;
    }
}

