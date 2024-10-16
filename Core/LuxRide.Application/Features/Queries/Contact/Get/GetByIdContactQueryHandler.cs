using LuxRide.Application.Exceptions;
using LuxRide.Application.Features.Queries.Contact.DTOs;
using LuxRide.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Queries.Contact.Get
{
	public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, ContactDto>
	{
		private readonly IContactRepository _contactRepository;

		public GetByIdContactQueryHandler(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}
		public async Task<ContactDto> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
		{
			var contact = await _contactRepository.GetAsync(x=>x.Id ==request.Id);

			if (contact is null)
				throw new NotFoundException("Conatact Not Found");

			return new ContactDto {
			Name = contact.Name,
			Email = contact.Email,
			Subject = contact.Subject,
			Message = contact.Message,
			RecordDateTime = contact.RecordDateTime,
			};
		}
	}
}
