using LuxRide.Application.Features.Commands.Class.Create;
using LuxRide.Application.Features.Queries.Class.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/class")]
	[ApiController]
	public class ClassController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ClassController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateClassCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdateClassCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] DeleteClassCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllClassesQuery query)
		{

			return Ok(await _mediator.Send(query));
		}

		[HttpGet("getById")]
		public async Task<IActionResult> GetById([FromQuery] GetClassByIdQuery query)
		{

			return Ok(await _mediator.Send(query));
		}
	}
}
