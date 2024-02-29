using System;
using Entities.Models;

namespace Business.Abstracts;

public interface ICategoryService
{
    Category? GetById(Guid id);

    Task<Category?> GetByIdAsync(Guid id);

    Category? GetCategoryNameWithProduct(string categoryName);

    IList<Category> GetAll(Category category);

    Task<IList<Category>> GetAllAsync(Category category);

    Category Add(Category category);

    Task<Category> AddAsync(Category category);

    Category Update(Category category);

    Task<Category> UpdateAsync(Category category);

    void DeleteById(Guid id);

    Task DeleteByIdAsync(Guid id);

}

