using LuxRide.Application.Features.Commands.Brand.Create;
using LuxRide.Application.Features.Queries.Brand.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/brand")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public BrandsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateBrandCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdateBrandCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] DeleteBrandCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllBrandsQuery query)
		{

			return Ok(await _mediator.Send(query));
		}

		[HttpGet("getById")]
		public async Task<IActionResult> GetById([FromQuery] GetBrandByIdQuery query)
		{

			return Ok(await _mediator.Send(query));
		}
	}
}
