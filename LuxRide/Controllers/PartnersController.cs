using LuxRide.Application.Features.Commands.Partner.Create;
using LuxRide.Application.Features.Commands.Partner.Delete;
using LuxRide.Application.Features.Commands.Partner.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LuxRide.Application.Features.Queries.Team.Get;
using LuxRide.Application.Features.Queries.Partner.Get;

namespace LuxRide.Controllers
{
	[Route("api/partner")]
	[ApiController]
	public class PartnersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public PartnersController(IMediator mediator)
		{
			_mediator = mediator;
		}




		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreatePartnerCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] UpdatePartnerCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpDelete]
		public async Task<IActionResult> Delete([FromQuery] DeletePartnerCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetPartnerAllQuery query)
		{

			return Ok(await _mediator.Send(query));
		}

		[HttpGet("getById")]
		public async Task<IActionResult> GetById([FromQuery] GetPartnerByIdQuery query)
		{

			return Ok(await _mediator.Send(query));
		}
	}
}
