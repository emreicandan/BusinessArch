using System;
using Business.Abstracts;
using Business.Validations;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using DataAccess.Abstracts;
using Entities.Models;

namespace Business.Concretes;

public class CategoryMenager : ICategoryService
{
    private readonly CategoryValidations _categoryValidations;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryMenager(CategoryValidations categoryValidations,
        ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        _categoryValidations = categoryValidations;
    }

    public Category Add(Category category)
    {
        _categoryValidations.CheckCategoryName(category).Wait();
        _categoryValidations.CategoryMustNotBeEmpty(category).Wait();
        return _categoryRepository.Add(category);
    }
    [CacheRemoveAspect("Business.Abstracts.ICategoryService.GetAllAsync")]
    public async Task<Category> AddAsync(Category category)
    {
        await _categoryValidations.CheckCategoryName(category);
        await _categoryValidations.CategoryMustNotBeEmpty(category);
        return await _categoryRepository.AddAsync(category);
    }

    public void DeleteById(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        _categoryValidations.CategoryMustNotBeEmpty(category).Wait();
        _categoryRepository.Delete(category);
    }
    [CacheRemoveAspect("Business.Abstracts.ICategoryService.GetAllAsync")]
    public async Task DeleteByIdAsync(Guid id)
    {
        var category = _categoryRepository.Get(c => c.Id == id);
        await _categoryValidations.CategoryMustNotBeEmpty(category);
        await _categoryRepository.DeleteAsync(category);
    }

    public IList<Category> GetAll()
    {
        return _categoryRepository.GetAll().ToList();
    }
    [PerformanceAspect(0)]
    [CacheAspect(10)]
    public async Task<IList<Category>> GetAllAsync()
    {
        var categoryList = await _categoryRepository.GetAllAsync();
        return categoryList.ToList();
    }

    public Category? GetById(Guid id)
    {
        return _categoryRepository.Get(c => c.Id == id);
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _categoryRepository.GetAsync(c => c.Id == id);
    }

    public IList<Category> GetAllCategoryName(string categoryName)
    {
        return _categoryRepository.GetAll(c => c.Name == categoryName).ToList();
    }

    public Category Update(Category category)
    {
        return _categoryRepository.Update(category);
    }
    [CacheRemoveAspect("Business.Abstracts.ICategoryService.GetAllAsync")]
    public async Task<Category> UpdateAsync(Category category)
    {
        return await _categoryRepository.UpdateAsync(category);
    }
}

