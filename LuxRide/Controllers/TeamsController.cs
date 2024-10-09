using LuxRide.Application.Features.Commands.Team.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/team")]
	[ApiController]
	public class TeamsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TeamsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateTeamCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
	}
}
