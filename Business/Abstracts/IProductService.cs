using System;
using Entities.DTOs;
using Entities.Models;

namespace Business.Abstracts;


	public interface IProductService
	{

	Product? GetById(Guid id);

	Task<Product?> GetByIdAsync(Guid id);

	IList<Product> GetAllByProductNameWithCategory(string productName);

	Task<IList<Product>> GetAllByProductNameWithCategoryAsync(string productName);

	IList<Product> GetAll();

	Task<IList<Product>> GetAllAsync();

    IList<Product> GetAllByProductName(string productName);

    Task<IList<Product>> GetAllByProductNameAsync(string productName);

	Product Add(AddProductDto addProductDto);

	Task<Product> AddAsync(AddProductDto addProductDto);

	Product Update(Product product);

	Task<Product> UpdateAsync(Product product);

	void DeleteById(Guid id);

	Task DeleteByIdAsync(Guid id);

}
