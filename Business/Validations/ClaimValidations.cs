using System;
using Business.Tools.Exceptions;
using Core.Entities;

namespace Business.Validations;

public class ClaimValidations
{
	public async Task IsClaimEmpty(Claim? claim)
	{
		if (claim == null)
		{
			throw new ValidationException("Claim must not be empty", 400);
		}
		await Task.CompletedTask;
	}
}

