using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Abouts;
using LuxRide.Infrastructure;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Review.Update
{
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand,bool>
	{
		private readonly IReviewRepository _reviewRepository;
		private readonly IUserManager _userManager;
		private readonly IOptions<FileSettings> _fileSettings;

		public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IUserManager userManager, IOptions<FileSettings> fileSettings)
		{
			_reviewRepository = reviewRepository;
			_userManager = userManager;
			_fileSettings = fileSettings;
		}

		public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var userId = _userManager.GetCurrentUserId();
			var review = await _reviewRepository.GetAsync(x=>x.Id==request.Id);
			if (review != null)
				throw new NotFoundException("Review not Found.");

			if (request.Rate > 5)
			{
				request.Rate = 5;
			}

			if (request.Photo is not null)
			{
				if (request.Photo.IsImage())
				{
					(string path, string fileName) = await request.Photo.SaveAsync(_fileSettings.Value.CreateSubFolders(_fileSettings.Value.Path,
					_fileSettings.Value.ReviewSettings.ReviewName,
						request.Name, _fileSettings.Value.ReviewSettings.Photos));
					if (File.Exists(review.Path))
					{
						File.Delete(review.Path);
					}
					review.SetDetails(request.Name, request.Position, request.Rate,request.Content,path);


				}
				else
				{
					throw new ExtensionException("File content is not Valid. Please upload image.");
				}
			}
			else
			{
				review.SetDetails(request.Name, request.Position, request.Rate, request.Content, review.Path);


			}

			review.SetEditFields(userId);

			await _reviewRepository.Update(review);
			await _reviewRepository.Commit();
			return true;
		}
	}
}
