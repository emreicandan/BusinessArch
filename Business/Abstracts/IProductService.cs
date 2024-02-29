using System;
using Entities.Models;

namespace Business.Abstracts;


	public interface IProductService
	{

	Product? GetById(Guid id);

	Task<Product?> GetByIdAsync(Guid id);

	Product? GetByProductNameWithCategory(string productName);

	Task<Product?> GetByProductNameWithCategoryAsync(string productName);


	IList<Product> GetAll(Product product);

	Task<IList<Product>> GetAllAsync(Product product);

    Product GetAllByProductName(string productName);

    Task<Product> GetAllByProductNameAsync(string productName);

	Product Add(Product product);

	Task<Product> AddAsync(Product product);

	Product Update(Product product);

	Task<Product> UpdateAsync(Product product);

	void DeleteById(Guid id);

	Task DeleteByIdAsync(Guid id);

}
