using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Interfaces
{
	public interface IEmailManager
	{
		public Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = false);
		public Task SendVerificationEmail(string email, string verificationUrl);
		public Task SendOtpEmailAsync(string toEmail, string otp);
	}
}
