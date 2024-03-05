using System;
using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Entities.Models;

namespace Business.Concretes
{
	public class ProductTransactionMenager:IProductTransactionService
	{
        private readonly IProductTransactionRepository _productTransactionRepository;
        private readonly ProductTransacitonValidations _productTransacitonValidations;
		public ProductTransactionMenager(IProductTransactionRepository productTransactionRepository,
            ProductTransacitonValidations productTransacitonValidations)
		{
            _productTransactionRepository = productTransactionRepository;
            _productTransacitonValidations = productTransacitonValidations;
		}

        public ProductTransaction Add(ProductTransaction productTransaction)
        {
            _productTransacitonValidations.ProductTransactionMustNotBeEmpty(productTransaction).Wait();
            return _productTransactionRepository.Add(productTransaction);
        }

        public async Task<ProductTransaction> AddAsync(ProductTransaction productTransaction)
        {
            await _productTransacitonValidations.ProductTransactionMustNotBeEmpty(productTransaction);
            return await _productTransactionRepository.AddAsync(productTransaction);
        }

        public void DeleteById(Guid id)
        {
           var pt = _productTransactionRepository.Get(pt => pt.Id == id);
            _productTransacitonValidations.ProductTransactionMustNotBeEmpty(pt).Wait();
            _productTransactionRepository.Delete(pt);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var pt = _productTransactionRepository.Get(pt => pt.Id == id);
            await _productTransacitonValidations.ProductTransactionMustNotBeEmpty(pt);
            await _productTransactionRepository.DeleteAsync(pt);
        }

        public IList<ProductTransaction> GetAll()
        {
            return _productTransactionRepository.GetAll().ToList();
        }

        public async Task<IList<ProductTransaction>> GetAllAsync()
        {
            var pt = await _productTransactionRepository.GetAllAsync();
            return pt.ToList();
        }

        public ProductTransaction? GetById(Guid id)
        {
            return _productTransactionRepository.Get(pt => pt.Id == id);
        }

        public async Task<ProductTransaction?> GetByIdAsync(Guid id)
        {
            return await _productTransactionRepository.GetAsync(pt => pt.Id == id);
        }

        public ProductTransaction Update(ProductTransaction productTransaction)
        {
            return _productTransactionRepository.Update(productTransaction);
        }

        public Task<ProductTransaction> UpdateAsync(ProductTransaction productTransaction)
        {
            return _productTransactionRepository.UpdateAsync(productTransaction);
        }
    }
}

