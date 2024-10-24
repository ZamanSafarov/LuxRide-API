using LuxRide.Application.Features.Commands.Faq.Create;
using LuxRide.Application.Features.Commands.Fleet.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/fleet")]
	[ApiController]
	public class FleetsController : ControllerBase
	{
		private  readonly IMediator _mediator;

		public FleetsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromForm]FleetCreateCommand command)
		{

			 return	Ok(await _mediator.Send(command));
		}

	}
}
