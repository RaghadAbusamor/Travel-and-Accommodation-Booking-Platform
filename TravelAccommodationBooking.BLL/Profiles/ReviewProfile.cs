using AutoMapper;
using TravelAccommodationBooking.BLL.Commands.ReviewCommands;
using TravelAccommodationBooking.BLL.DTO.Review;
using TravelAccommodationBooking.BLL.Queries.ReviewQueries;
using TravelAccommodationBooking.Model.Entities.Hotel;

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