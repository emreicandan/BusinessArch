using System;
using Core;

namespace Entities.Models;

public class OrderDetail:Entity<Guid>
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public Guid ProductTransactionId { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
    public ProductTransaction ProductTransaction { get; set; }
}

