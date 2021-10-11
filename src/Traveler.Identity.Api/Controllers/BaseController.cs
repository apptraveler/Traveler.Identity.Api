using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Traveler.Identity.Api.Filters;
using Traveler.Identity.Domain.Exceptions;

namespace Traveler.Identity.Api.Controllers
{
	[Route("your-project-name/[controller]/v{version:apiVersion}")]
	[ServiceFilter(typeof(GlobalExceptionFilterAttribute))]
	public class BaseController : Controller
	{
		private readonly ExceptionNotificationHandler _notifications;

		protected IEnumerable<ExceptionNotification> Notifications => _notifications.GetNotifications();

		protected BaseController(INotificationHandler<ExceptionNotification> notifications)
		{
			_notifications = (ExceptionNotificationHandler) notifications;
		}

		protected bool IsValidOperation()
		{
			return (!_notifications.HasNotifications());
		}

		protected new IActionResult Response(IActionResult action)
		{
			if (IsValidOperation())
			{
				return action;
			}

			return BadRequest
			(
				new
				{
					success = false,
					errors = _notifications.GetNotifications()
				}
			);
		}
	}
}