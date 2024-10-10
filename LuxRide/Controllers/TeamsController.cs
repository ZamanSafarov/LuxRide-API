using LuxRide.Application.Features.Commands.Team.Create;
using LuxRide.Application.Features.Commands.Team.Delete;
using LuxRide.Application.Features.Commands.Team.Update;
using LuxRide.Application.Features.Queries.Team.Get;
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
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdateTeamCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] DeleteTeamCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery]GetAllQuery query)
		{
			
			return Ok(await _mediator.Send(query));
		}

		[HttpGet("getById")]
		public async Task<IActionResult> GetById([FromQuery] GetByIdQuery query)
		{

			return Ok(await _mediator.Send(query));
		}
	}
}
