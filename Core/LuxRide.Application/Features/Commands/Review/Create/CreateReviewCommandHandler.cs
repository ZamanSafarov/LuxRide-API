using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Review.Create
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, bool>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IUserManager _userManager;
		private readonly IOptions<FileSettings> _fileSettings;

		public CreateReviewCommandHandler(IReviewRepository reviewRepository, IUserManager userManager, IOptions<FileSettings> fileSettings)
		{
			_reviewRepository = reviewRepository;
			_userManager = userManager;
			_fileSettings = fileSettings;
		}

		public async Task<bool> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			var userId= _userManager.GetCurrentUserId();

			var review = new Domain.Entities.Abouts.Review();

			if (request.Photo.IsImage() == false)
				throw new ExtensionException("File Type is not Valid. Please upload image.");

			(string path, string fileName) = await  request.Photo.SaveAsync(
				_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
				_fileSettings.Value.ReviewSettings.ReviewName,
				request.Name,
				_fileSettings.Value.ReviewSettings.Photos));
			if (request.Rate>5)
			{
				request.Rate = 5;
			}
			review.SetDetails(request.Name,request.Position,request.Rate,request.Content,path);

			review.SetAuditDetails(userId);

			await _reviewRepository.AddAsync(review);
			await _reviewRepository.Commit();

			return true;
		}
	}
}
