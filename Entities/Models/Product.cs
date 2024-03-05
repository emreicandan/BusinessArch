using System;
using Core;
using Core.Entities;

namespace Entities.Models;

public class Product:Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
    public Product()
    {
        ProductTransactions = new HashSet<ProductTransaction>();
    }

}

