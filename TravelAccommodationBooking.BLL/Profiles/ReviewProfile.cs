using Application.Commands.ReviewCommands;
using AutoMapper;
using Domain.Entities;
using TravelAccommodationBooking.BLL.DTO.Review;
using TravelAccommodationBooking.BLL.Queries.ReviewQueries;

namespace TravelAccommodationBooking.BLL.Profiles;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, ReviewDto>();

        // Commands And Queries
        CreateMap<ReviewForCreationDto, CreateReviewCommand>();
        CreateMap<CreateReviewCommand, Review>();
        CreateMap<ReviewQueryDto, GetReviewsQuery>();
    }
}