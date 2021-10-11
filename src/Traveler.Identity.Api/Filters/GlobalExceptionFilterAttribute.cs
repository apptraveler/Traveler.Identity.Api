using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Traveler.Identity.Api.Filters.ErrorsModels;

namespace Traveler.Identity.Api.Filters
{
	public class GlobalExceptionFilterAttribute : Attribute, IExceptionFilter
	{
		public GlobalExceptionFilterAttribute() { }

		public void OnException(ExceptionContext context)
		{
			context.Result = new BadRequestObjectResult(
				new DefaultError(false, 
					new ErrorsResponse[]
					{
						new ErrorsResponse(Environment.GetEnvironmentVariable("GlobalErrorCode"),
							Environment.GetEnvironmentVariable("GlobalErrorMessage"),
							DateTime.Now)
					}
				)
			);
		}
	}
}