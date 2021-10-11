using System;
using MediatR;

namespace Traveler.Identity.Domain.Events
{
	public class Event : INotification
	{
		public DateTime Timestamp { get; set; }

		protected Event()
		{
			Timestamp = DateTime.Now;
		}
	}
}