using System;
using Entities.DTOs;
using Entities.Models;

namespace Business.Abstracts;

public interface IOrderService
{
    Order? GetById(Guid id);

    Task<Order?> GetByIdAsync(Guid id);

    IList<Order> GetAll();

    Task<IList<Order>> GetAllAsync();

    Order Add(AddOrderDto addOrderDto);

    Task<Order> AddAsync(AddOrderDto addOrderDto);

    Order Update(Order order);

    Task<Order> UpdateAsync(Order order);

    void DeleteById(Guid id);

    Task DeleteByIdAsync(Guid id);
}

