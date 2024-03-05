using System;
using Business.Tools.Exceptions;
using Entities.Models;

namespace Business.Validations;

public class ProductTransacitonValidations
{

    public async Task ProductTransactionMustNotBeEmpty(ProductTransaction productTransaciton)
    {
        if(productTransaciton == null)
        {
            throw new ValidationException("Product Transaciton must not be empty");
        }

        await Task.CompletedTask;
    }
}

