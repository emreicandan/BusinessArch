using System;
using Business.Abstracts;
using Business.Validations;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Transaction;
using DataAccess.Abstracts;
using Entities.DTOs;
using Entities.Models;

namespace Business.Concretes
{
	public class OrderMenager:IOrderService
	{
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductTransactionService _productTransactionService;
        private readonly OrderValidations _orderValidations;

		public OrderMenager(IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            OrderValidations orderValidations,
            IProductTransactionService productTransactionService)
		{
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productTransactionService = productTransactionService;
            _orderValidations = orderValidations;
		}

        public Order Add(AddOrderDto addOrderDto)
        {
            _orderValidations.CheckProductQuantity(addOrderDto).Wait();
            _orderValidations.CheckStock(addOrderDto).Wait();
            _orderValidations.CheckTransactionCount(addOrderDto).Wait();

            var addedOrder = _orderRepository.Add(new()
            {
                UserId = addOrderDto.UserId,
                CreatedDate = DateTime.UtcNow
            });

            addOrderDto.productTransactions.ToList().ForEach(productTransaction =>
            {
                productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
                var addedProductTransaction = _productTransactionService.Add(productTransaction);
                _orderDetailRepository.Add(new()
                {
                    ProductId = productTransaction.ProductId,
                    OrderId = addedOrder.Id,
                    ProductTransactionId = addedProductTransaction.Id
                });
            });
            return addedOrder;
        }
        [TransactionScopedAspect]
        [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
        public async Task<Order> AddAsync(AddOrderDto addOrderDto)
        {
            await _orderValidations.CheckProductQuantity(addOrderDto);
            await _orderValidations.CheckStock(addOrderDto);
            await _orderValidations.CheckTransactionCount(addOrderDto);

            var addedOrder = await _orderRepository.AddAsync(new()
            {
                UserId = addOrderDto.UserId,
                CreatedDate = DateTime.UtcNow
            });

            addOrderDto.productTransactions.ToList().ForEach(async productTransaction =>
            {
                productTransaction.Quantity = productTransaction.Quantity > 0 ? -1 * productTransaction.Quantity : productTransaction.Quantity;
                var addedProductTransaction = await _productTransactionService.AddAsync(productTransaction);
                await _orderDetailRepository.AddAsync(new()
                {
                    ProductId = productTransaction.ProductId,
                    OrderId = addedOrder.Id,
                    ProductTransactionId = addedProductTransaction.Id
                });
            });
            return addedOrder;
        }

        public void DeleteById(Guid id)
        {
           var order = _orderRepository.Get(o => o.Id == id);
           _orderValidations.OrderMustNotBeEmpty(order).Wait();
            _orderRepository.Delete(order);
        }

        [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
        public async Task DeleteByIdAsync(Guid id)
        {
            var order = _orderRepository.Get(o => o.Id == id);
            await _orderValidations.OrderMustNotBeEmpty(order);
            await _orderRepository.DeleteAsync(order);
        }

        public IList<Order> GetAll()
        {
            return _orderRepository.GetAll().ToList();
        }
        [CacheAspect(10)]
        public async Task<IList<Order>> GetAllAsync()
        {
            var orderList = await _orderRepository.GetAllAsync();
            return orderList.ToList();
        }

        public Order? GetById(Guid id)
        {
            return _orderRepository.Get(o => o.Id == id);
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return  await _orderRepository.GetAsync(o => o.Id == id);
        }

        public Order Update(Order order)
        {
            return _orderRepository.Update(order);
        }

        [CacheRemoveAspect("Business.Abstracts.IOrderService.GetAllAsync")]
        public async Task<Order> UpdateAsync(Order order)
        {
            return await _orderRepository.UpdateAsync(order);
        }
    }
}

