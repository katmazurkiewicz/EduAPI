using EduAPI.Data.Entities;
namespace EduAPI.Data.DAL.Interfaces
{
    public interface IReviewRepository: IReadRepo<Review>, ICudRepo<Review>
    {
    }
}
