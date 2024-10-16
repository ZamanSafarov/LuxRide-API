using LuxRide.Application.Features.Commands.About.Create;
using LuxRide.Application.Features.Commands.About.Create;
using LuxRide.Application.Features.Commands.About.Delete;
using LuxRide.Application.Features.Commands.About.Update;
using LuxRide.Application.Features.Queries.About.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/about")]
	[ApiController]
	public class AboutController:ControllerBase
	{
		private readonly IMediator _mediator;

		public AboutController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateAboutCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdateAboutCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] DeleteAboutCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetAboutQuery query)
		{

			return Ok(await _mediator.Send(query));
		}

	
	}
}
