using System;
using Business.Tools.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Validations;

public class CustomExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

	public CustomExceptionHandlerMiddleware(RequestDelegate next , ILogger<CustomExceptionHandlerMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch(Exception ex)
		{

			if(ex.InnerException as ValidationException != null)
			{
				await HandleValidationException(ex.InnerException as ValidationException, context);
				return;
			}
			_logger.LogError("İç Hata Oluştu :" +ex.Message);
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			context.Response.ContentType = Text.Plain;
			await context.Response.WriteAsync("Internal Server Error");
		};
	}
	public async Task HandleValidationException(ValidationException ex , HttpContext context)
	{
        context.Response.StatusCode = ex.StatusCode;
        context.Response.ContentType = Text.Plain;
        await context.Response.WriteAsync(ex.Message);
    }
}

