using System;
namespace Entities.DTOs;

public class AddProductDto
{
	public Guid CategoryId { get; set; }
	public string Name { get; set; }
	public decimal Price { get; set; }
	public string? Description { get; set; }
	public bool IsActive { get; set; }
}

