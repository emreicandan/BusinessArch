using System;
using Business.Abstracts;
using Business.Validations;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ProductMenager : IProductService
{
    private readonly ProductValidations _productValidations;
    private readonly IProductRepository _productRepository;

    public ProductMenager(IProductRepository productRepository,
        ProductValidations productValidations)
    {
        _productRepository = productRepository;
        _productValidations = productValidations;
    }

    public Product Add(AddProductDto addProductDto)
    {
        var product = new Product();
        product.CategoryId = addProductDto.CategoryId;
        product.Name = addProductDto.Name;
        product.Price = addProductDto.Price;
        product.Description = addProductDto.Description;
        _productValidations.CheckProductName(product).Wait();
        _productValidations.ProductMustNotBeEmpty(product).Wait();
        _productRepository.Add(product);
        return product;
    }
    [TransactionScopedAspect]
    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    public async Task<Product> AddAsync(AddProductDto addProductDto)
    {
        var product = new Product();
        product.CategoryId = addProductDto.CategoryId;
        product.Name = addProductDto.Name;
        product.Price = addProductDto.Price;
        product.Description = addProductDto.Description;
        product.IsActive = addProductDto.IsActive;
        await _productRepository.AddAsync(product);
        return product;
    }
  
    public void DeleteById(Guid id)
    {
        var product = _productRepository.Get(p => p.Id == id);
        _productValidations.ProductMustNotBeEmpty(product).Wait();
        _productRepository.Delete(product);
    }
    [TransactionScopedAspect]
    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    public async Task DeleteByIdAsync(Guid id)
    {
        var product = _productRepository.Get(p => p.Id == id);
        await _productValidations.ProductMustNotBeEmpty(product);
        await _productRepository.DeleteAsync(product);
    }

    public IList<Product> GetAll()
    {
        return _productRepository.GetAll().ToList();
    }
    [CacheAspect(10)]
    [PerformanceAspect(0)]
    public async Task<IList<Product>> GetAllAsync()
    {
        var productList = await _productRepository.GetAllAsync();
        return productList.ToList();
    }
  
    public IList<Product> GetAllByProductName(string productName)
    {
        return _productRepository.GetAll(p => p.Name == productName).ToList();
    }
  
    public async Task<IList<Product>> GetAllByProductNameAsync(string productName)
    {
        var productList = await _productRepository.GetAllAsync(p => p.Name == productName);
        return productList.ToList();
    }
  
    public Product? GetById(Guid id)
    {
        return _productRepository.Get(p => p.Id == id);
    }
  
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _productRepository.GetAsync(p => p.Id == id);
    }
  
    public IList<Product> GetAllByProductNameWithCategory(string productName)
    {
        return _productRepository.GetAll(p=>p.Name == productName , include: product => product.Include(p=>p.Category)).ToList();
    }
  
    public async Task<IList<Product>> GetAllByProductNameWithCategoryAsync(string productName)
    {
        var product = await _productRepository.GetAllAsync(p => p.Name == productName, include: product => product.Include(p => p.Category));
        return product.ToList();
    }
  
    public Product Update(Product product)
    {
        _productValidations.CheckProductName(product).Wait();
        return _productRepository.Update(product);
    }
    [CacheRemoveAspect("Business.Abstracts.IProductService.GetAllAsync")]
    public async Task<Product> UpdateAsync(Product product)
    {
        await _productValidations.CheckProductName(product);
        return await _productRepository.UpdateAsync(product);
    }
}

