namespace EduAPI.Services.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReadReviewDTO>();
            CreateMap<WriteReviewDTO, Review>();
        }

    }
}
