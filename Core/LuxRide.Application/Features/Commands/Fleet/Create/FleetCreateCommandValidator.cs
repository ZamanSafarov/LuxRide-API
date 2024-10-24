using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Fleet.Create
{
	public class FleetCreateCommandValidator:AbstractValidator<FleetCreateCommand>
	{
		public FleetCreateCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Fleet name is required.")
				.MaximumLength(100).WithMessage("Fleet name must not exceed 100 characters.");

			RuleFor(x => x.PassangerCapacity)
				.GreaterThan(0).WithMessage("Passenger capacity must be greater than 0.");

			RuleFor(x => x.HourlyRate)
				.GreaterThanOrEqualTo(0).WithMessage("Hourly rate must be non-negative.");

			RuleFor(x => x.DailyRate)
				.GreaterThanOrEqualTo(0).WithMessage("Daily rate must be non-negative.");

			RuleFor(x => x.AirportTransferRate)
				.GreaterThanOrEqualTo(0).WithMessage("Airport transfer rate must be non-negative.");

			RuleForEach(x => x.FleetImages).ChildRules(fleetImage =>
			{
				fleetImage.RuleFor(x => x.FleetImage)
					.NotEmpty().WithMessage("Image path is required.");

				fleetImage.RuleFor(x => x.IsMain)
					.NotNull().WithMessage("IsMain flag is required.");
			});

			RuleForEach(x => x.FleetAvailabilities).ChildRules(availability =>
			{
				availability.RuleFor(x => x.Date)
					.GreaterThanOrEqualTo(DateTime.Today).WithMessage("Availability date must be today or later.");

				availability.RuleForEach(x => x.AvailableTimeSlots).ChildRules(timeSlot =>
				{
					timeSlot.RuleFor(x => x.StartTime)
						.NotEmpty().WithMessage("Time slot start time is required.");

					timeSlot.RuleFor(x => x.EndTime)
						.NotEmpty().WithMessage("Time slot end time is required.")
						.GreaterThan(x => x.StartTime).WithMessage("End time must be greater than start time.");
				});
			});
		}
	}
}
