using System;
using Entities.Models;

namespace Business.Abstracts;

public interface ICategoryService
{
    Category? GetById(Guid id);

    Task<Category?> GetByIdAsync(Guid id);

    IList<Category> GetAllCategoryName(string categoryName);

    IList<Category> GetAll();

    Task<IList<Category>> GetAllAsync();

    Category Add(Category category);

    Task<Category> AddAsync(Category category);

    Category Update(Category category);

    Task<Category> UpdateAsync(Category category);

    void DeleteById(Guid id);

    Task DeleteByIdAsync(Guid id);

}

