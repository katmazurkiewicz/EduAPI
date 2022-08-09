using EduAPI.Data.Context;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduAPI.Data.DAL.Repositories
{
    public class AuthorRepository: IAuthorRepository
    {
        protected EduContext _context;
        public AuthorRepository(EduContext context)
        {
            _context = context;
        }

        public async Task<Author> GetSingleAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }
        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task<IEnumerable<Material>> GetTopMaterialsAsync(int id)
        {
            var author = await _context.Authors
                                    .Include(a => a.Materials)
                                    .ThenInclude(m => m.Reviews)
                                    .FirstOrDefaultAsync(a => a.Id == id);
            //if autor is null throw exception
            var topMaterials = new List<Material>();
            foreach(var material in author.Materials)
            {
                var reviewValues = new List<int>();
                if (material.Reviews != null && material.Reviews.Count() > 0)
                {
                    foreach (var review in material.Reviews)
                    {
                        reviewValues.Add(review.Points);
                    }
                    if (reviewValues.Average() > 5) topMaterials.Add(material);
                }
            }
            //if topmaterials is empty throw exception
            return topMaterials;
        }
        public async Task<IEnumerable<Author>> GetMostProductiveAsync()
        {
            var authorList = await _context.Authors.Include(a => a.Materials).ToListAsync();
            authorList = authorList.OrderByDescending(a => a.CreatedTotal).ToList();
            var topAuthor = authorList.FirstOrDefault();
            var topList = authorList.Where(a => a.CreatedTotal == topAuthor.CreatedTotal);
            return topList;
        }
    }
}
