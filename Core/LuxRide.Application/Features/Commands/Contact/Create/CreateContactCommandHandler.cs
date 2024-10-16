using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Contact.Create
{
	public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, bool>
	{
		private readonly IContactRepository _contactRepository;
		private readonly IEmailManager _emailManager;

		public CreateContactCommandHandler(IContactRepository contactRepository, IEmailManager emailManager)
		{
			_contactRepository = contactRepository;
			_emailManager = emailManager;
		}

		public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
		{
			var contact = new Domain.Entities.Contacts.Contact();
			contact.SetDetails(request.Name,request.Email,request.Subject,request.Message);


			var body = "<!DOCTYPE html>\r\n" +
				"<html lang=\"en\">\r\n" +
				"<head>\r\n   " +
				" <meta charset=\"UTF-8\">\r\n" +
				"    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n" +
				"    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n" +
				"    <title>Contact Us Response</title>\r\n   " +
				" <style>\r\n        " +
				"body {\r\n   " +
				"font-family: Arial, sans-serif;\r\n           " +
				" line-height: 1.6;\r\n         " +
				"   color: #333;\r\n       " +
				" }\r\n      " +
				"  .container {\r\n     " +
				"       width: 80%;\r\n     " +
				"       margin: 0 auto;\r\n       " +
				"     padding: 20px;\r\n        " +
				"    border: 1px solid #ddd;\r\n       " +
				"     border-radius: 10px;\r\n         " +
				"   background-color: #f9f9f9;\r\n     " +
				"   }\r\n        h1 {\r\n        " +
				"    color: #0056b3;\r\n        }\r\n      " +
				"  p {\r\n     " +
				"       margin-bottom: 10px;\r\n     " +
				"   }\r\n        .footer {\r\n          " +
				"  margin-top: 20px;\r\n            color: #555;\r\n   " +
				"     }\r\n  " +
				"  </style>\r\n" +
				"</head>\r\n" +
				"<body>\r\n" +
				"    <div class=\"container\">\r\n" +
				"        <h1>Thank You for Contacting Us</h1>\r\n" +
				$"        <p>Dear {request.Name},</p>\r\n" +
				"        <p>We have received your message with the following details:</p>\r\n" +
				$"        <p><strong>Subject:</strong> {request.Subject}</p>\r\n" +
				$"        <p><strong>Message:</strong> {request.Message}</p>\r\n " +
				"       <p>We appreciate you reaching out to us and will respond to your inquiry as soon as possible.</p>\r\n" +
				"        <p>If you need immediate assistance, feel free to reply to this email or contact our support team directly.</p>\r\n " +
				"       <p>Thank you once again for getting in touch.</p>\r\n " +
				"       <p>Best regards,</p>\r\n" +
				"        <p>LuxRide Fleet Renting Company</p>\r\n " +
				"       <div class=\"footer\">\r\n" +
				"            <p><strong>Contact Us:</strong></p>\r\n" +
				"            <p>Email: support@luxride.com</p>\r\n" +
				"            <p>Phone: +994055555555</p>\r\n" +
				"        </div>\r\n" +
				"    </div>\r\n" +
				"</body>\r\n" +
				"</html>\r\n";
			await _contactRepository.AddAsync(contact);
			await _contactRepository.Commit();

			 await	_emailManager.SendEmailAsync(request.Email,"Contact Us", body,true);
			return true;
		}
	}
}
