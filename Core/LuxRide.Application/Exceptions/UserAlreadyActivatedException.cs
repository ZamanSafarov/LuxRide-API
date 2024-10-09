using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Exceptions
{
	public class UserAlreadyActivatedException : Exception
	{
		public UserAlreadyActivatedException()
		{
		}

		public UserAlreadyActivatedException(string? message) : base(message)
		{
		}

		public UserAlreadyActivatedException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

	}
}
