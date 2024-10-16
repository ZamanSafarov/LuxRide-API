using LuxRide.Application.Features.Commands.Contact.Create;
using LuxRide.Application.Features.Queries.Contact.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LuxRide.Controllers
{
	[Route("api/contact")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ContactsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> UserContact([FromQuery]CreateContactCommand command)
		{
			await _mediator.Send(command);	
			return Ok();
		}


		[HttpGet]
		public async Task<IActionResult> GetAll ([FromQuery] GetAllContactQuery query)
		{
			return Ok(await _mediator.Send(query));
		}


		[HttpGet("GetById")]
		public async Task<IActionResult> GetById([FromQuery] GetByIdContactQuery query)
		{
			return Ok(await _mediator.Send(query));
		}
	}
}
