using System;
using Business.Tools.Exceptions;
using Core.Entities;
using Core.Utilities.Security.Helper;

namespace Business.Validations
{
	public class AuthValidations
	{
		public async Task IsUserNull(User? user)
		{
			if (user == null)
			{
				throw new ValidationException("Username or password does not  match.", 500);
			}
            await Task.CompletedTask;
        }
		public async Task IsUserClaimNull(User user)
		{
			if (user.UserClaims.Count == 0)
			{
				throw new ValidationException("User has not any 'Claim'. Please contact to system menager");
			}
			await Task.CompletedTask;
		}
		public async Task PasswordValidate(User user,string password)
		{
			var result = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
			if (!result)
				throw new ValidationException("Username or password does not match.");
		}
	}
}

