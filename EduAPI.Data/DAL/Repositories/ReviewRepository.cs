using EduAPI.Data.Context;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduAPI.Data.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        protected EduContext _context;
        public ReviewRepository(EduContext context)
        {
            _context = context;
        }
        public void Add(Review review)
        {
            _context.Reviews.Add(review);
        }


        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
        }
        public async Task<Review> GetSingleAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }
        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
