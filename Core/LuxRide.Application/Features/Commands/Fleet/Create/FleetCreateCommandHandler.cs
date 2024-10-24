using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Fleets;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Fleet.Create
{
	public class FleetCreateCommandHandler : IRequestHandler<FleetCreateCommand, int>
	{
		private readonly IFleetRepository _repository;
		private readonly IUserManager _userManager;
		private readonly IOptions<FileSettings> _fileSettings;

		public FleetCreateCommandHandler(IFleetRepository repository, IUserManager userManager, IOptions<FileSettings> fileSettings)
		{
			_repository = repository;
			_userManager = userManager;
			_fileSettings = fileSettings;
		}

		public async Task<int> Handle(FleetCreateCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();

			var fleet = new Domain.Entities.Fleets.Fleet();

			fleet.SetDetails(request.Name,request.PassangerCapacity,request.IsAvailable,request.HourlyRate,request.DailyRate,request.AirportTransferRate,request.BrandId,request.ClassId);

			for (int i = 0; i < request.FleetImages.Count; i++)
			{
				if (request.FleetImages[i].FleetImage.IsImage()==false)
					throw new ExtensionException("File Type is not Valid. Please upload image.");

				var fleetImage = new FleetImage();

				(string path, string fileName) = await request.FleetImages[i].FleetImage.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
				_fileSettings.Value.FleetSettings.FleetName,
				request.Name, _fileSettings.Value.FleetSettings.Photos));

				fleetImage.SetDetails(path, request.FleetImages[i].IsMain);
				fleetImage.SetAuditDetails(userId);

				fleet.FleetImages.Add(fleetImage);

			}
			foreach (var availabilityDto in request.FleetAvailabilities)
			{
				var availability = new FleetAvailability();
				availability.SetDetails(availabilityDto.Date, availabilityDto.IsAvailable);

				foreach (var slots in availabilityDto.AvailableTimeSlots)
				{
					var timeSlot = new TimeSlot();

					timeSlot.SetDetails(slots.StartTime,slots.EndTime,slots.IsAvailable);

					timeSlot.SetAuditDetails(userId);
					availability.AvailableTimeSlots.Add(timeSlot);
				}

				availability.SetAuditDetails(userId);
				fleet.FleetAvailabilities.Add(availability);
			}

			fleet.SetAuditDetails(userId);

			await _repository.AddAsync(fleet);
			await _repository.Commit();


			return fleet.Id;

		}
	}
}
