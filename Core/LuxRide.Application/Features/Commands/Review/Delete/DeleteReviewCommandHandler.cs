using LuxRide.Application.Exceptions;
using LuxRide.Application.Interfaces;
using LuxRide.Domain.Entities.Abouts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Application.Features.Commands.Review.Delete
{
	public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
	{
		private readonly IReviewRepository _reviewRepository;

		public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
		{
			var review = await _reviewRepository.GetAsync(x=>x.Id == request.Id);
			if (review == null)
				throw new NotFoundException("Review not Found.");

			if (File.Exists(review.Path))
			{
				File.Delete(review.Path);
			} 


			await _reviewRepository.HardDeleteAsync(review);
			await _reviewRepository.Commit();
			return true;
		}
	}
}
