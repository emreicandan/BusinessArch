using System;
using Business.Abstracts;
using Business.Tools.Exceptions;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;

namespace Business.Validations;

public class OrderValidations
{
    private readonly IProductTransactionRepository _productTransactionRepository;

    public OrderValidations(IProductTransactionRepository productTransactionRepository)
    {
        _productTransactionRepository = productTransactionRepository;
    }

    public async Task OrderMustNotBeEmpty(Order? order)
    {
        if(order == null)
        {
            throw new ValidationException("Order must not be empty");
        }

        await Task.CompletedTask;
    }

    public async Task CheckProductQuantity(AddOrderDto addOrderDto)
    {
        if(addOrderDto.productTransactions.Where(pt=>pt.Quantity <= 0).Any())
        {
            throw new ValidationException("Product count must not be 0");
        }
        await Task.CompletedTask;
    }

    public async Task CheckTransactionCount(AddOrderDto addOrderDto)
    {
        if(addOrderDto.productTransactions.Count() == 0)
        {
            throw new ValidationException("Product list cannot be empty");
        }
        await Task.CompletedTask;
    }

    public async Task CheckStock(AddOrderDto addOrderDto)
    {
        var checkCount = addOrderDto.productTransactions.Select(t =>
         _productTransactionRepository.GetAll(pt => pt.ProductId == t.ProductId).Sum(transaction => transaction.Quantity) - t.Quantity)
             .Where(q => q < 0).Any();
        if (checkCount)
        {
            throw new ValidationException("We are has not any product stock. Please check stock count");
        }

        await Task.CompletedTask;
    }
}

