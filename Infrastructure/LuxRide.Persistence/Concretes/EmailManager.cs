using LuxRide.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace LuxRide.Persistence.Concretes
{
	public class EmailManager : IEmailManager
	{
		private readonly IConfiguration _config;
        public EmailManager(IConfiguration config)
        {
			_config= config;

		}
		public async Task SendEmailAsync(string toEmail,string subject,string body, bool isHtml = false)
		{
			var smtpHost = _config.GetSection("SmtpSettings:smtpServer").Value;
			var smtpPort = Convert.ToInt16(_config.GetSection("SmtpSettings:port").Value);
			string login = _config.GetSection("SmtpSettings:userName").Value;
			string password = _config.GetSection("SmtpSettings:password").Value;
			var ssl = Convert.ToBoolean(_config.GetSection("SmtpSettings:enableSsl").Value);

			var smtpClient = new SmtpClient(smtpHost, smtpPort)
			{
				Credentials = new NetworkCredential(login, password),
				EnableSsl = ssl
			};
			var mailMessage = new MailMessage
			{
				From = new MailAddress(login, _config.GetSection("SmtpSettings:displayName").Value),
				Subject = subject,
				Body = body,
				IsBodyHtml = true,
			};
			mailMessage.To.Add(toEmail);

			await smtpClient.SendMailAsync(mailMessage);
		}
        public async Task SendVerificationEmail(string email, string verificationUrl)
		{
			var subject = "Verify your email";
			var body = $"Please click the following link to verify your email: {verificationUrl}";

			await SendEmailAsync(email, subject,body,true);
		}



		public async Task SendOtpEmailAsync(string toEmail, string otp)
		{
			string subject = "Your OTP Code";
			string body = $"Your OTP code is: {otp}";

			await SendEmailAsync(toEmail, subject, body,true);
		}
	}
}
