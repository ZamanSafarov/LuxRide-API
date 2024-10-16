using LuxRide.Application.Features.Commands.Faq.Create;
using LuxRide.Application.Features.Commands.Team.Create;
using LuxRide.Application.Features.Commands.Team.Delete;
using LuxRide.Application.Features.Commands.Team.Update;
using LuxRide.Application.Features.Queries.Faq.Get;
using LuxRide.Application.Features.Queries.Team.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/faqs")]
	[ApiController]
	public class FAQsController:ControllerBase
	{
		private readonly IMediator _mediator;

		public FAQsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateFaqCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdateFaqCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] DeleteFaqCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllFaqsQuery query)
		{

			return Ok(await _mediator.Send(query));
		}

		[HttpGet("getById")]
		public async Task<IActionResult> GetById([FromQuery] GetFaqByIdQuery query)
		{

			return Ok(await _mediator.Send(query));
		}
	}
}
