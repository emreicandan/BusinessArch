using System;
using Entities.Models;

namespace Entities.DTOs;

public class AddOrderDto
{
    public Guid UserId { get; set; }

    public IList<ProductTransaction> productTransactions { get; set; }

    public AddOrderDto()
    {
        productTransactions = new List<ProductTransaction>();
    }
}

