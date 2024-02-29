﻿using System;
using Core;

namespace Entities.Models;

public class ProductTransaction:Entity<Guid>
{
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public Product Product { get; set; }
}

