using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Exceptions
{
	public class ExtensionException : Exception
	{
		public ExtensionException()
		{
		}

		public ExtensionException(string? message) : base(message)
		{
		}

		public ExtensionException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

	}
}
