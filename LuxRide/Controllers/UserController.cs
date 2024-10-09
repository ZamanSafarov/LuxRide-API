using LuxRide.Application.Features.Commands.User.ForgetPassword;
using LuxRide.Application.Features.Commands.User.Login;
using LuxRide.Application.Features.Commands.User.RefreshToken;
using LuxRide.Application.Features.Commands.User.Register;
using LuxRide.Application.Features.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LuxRide.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}
		[HttpGet("verify-email")]
		public async Task<IActionResult> VerifyEmail([FromQuery] VerifyEmailCommand command)
		{
			await _mediator.Send(command);
			return Ok();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(CreateAuthTokenCommand command)
		{
			return Ok(await _mediator.Send(command));
		}

		[HttpPost("refresh-token")]
		public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
		{

			return Ok(await _mediator.Send(command));
		}

		[HttpPost("send-otp")]
		public async Task<IActionResult> SendOTP(SendOTPToUserMailCommand command)
		{

			return Ok(await _mediator.Send(command));
		}
		[HttpPost("check-otp")]
		public async Task<IActionResult> CheckOTP(VerifyOTPFromUserCommand command)
		{
			return Ok(await _mediator.Send(command));
		}
		
		[HttpPut("reset-password")]
		public async Task<IActionResult> ResetPassword(ResetUserPasswordCommand command)
		{
			return Ok(await _mediator.Send(command));
		}
		[HttpGet("profile")]
		public async Task<IActionResult> Profile([FromQuery] int id)
		{
			var profileData = await _mediator.Send(new UserProfileQuery { Id = id });
			return Ok(profileData);
		}

		//[HttpPut("updateUser")]
		//public async Task<IActionResult> Update(UserUpdateCommand command)
		//{
		//	return Ok(await _mediator.Send(command));
		//}
	}
}
