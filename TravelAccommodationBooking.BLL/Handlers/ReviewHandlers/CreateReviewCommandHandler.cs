using Application.Commands.ReviewCommands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using TravelAccommodationBooking.BLL.DTO.Review;
using TravelAccommodationBooking.Model.Interfaces;

namespace TravelAccommodationBooking.BLL.Handlers.ReviewHandlers;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto?>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public CreateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<ReviewDto?> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var reviewToAdd = _mapper.Map<Review>(request);
        var addedReview = await _reviewRepository.InsertAsync(reviewToAdd);
        return addedReview is null ? null : _mapper.Map<ReviewDto>(addedReview);
    }
}