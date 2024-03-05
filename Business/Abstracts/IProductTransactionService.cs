using System;
using Entities.Models;

namespace Business.Abstracts;

public interface IProductTransactionService
{
    ProductTransaction? GetById(Guid id);

    Task<ProductTransaction?> GetByIdAsync(Guid id);

    IList<ProductTransaction> GetAll();

    Task<IList<ProductTransaction>> GetAllAsync();

    ProductTransaction Add(ProductTransaction productTransaction);

    Task<ProductTransaction> AddAsync(ProductTransaction productTransaction);

    ProductTransaction Update(ProductTransaction productTransaction);

    Task<ProductTransaction> UpdateAsync(ProductTransaction productTransaction);

    void DeleteById(Guid id);

    Task DeleteByIdAsync(Guid id);
}

