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
        public async Task<Author> GetSingleWithDetailsAsync(int id)
        {
            return await _context.Authors
                                    .Include(a => a.Materials)
                                    .ThenInclude(m => m.Reviews)
                                    .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Author>> GetAllWithDetailsAsync()
        {
            return await _context.Authors
                                    .Include(a => a.Materials)
                                    .ThenInclude(m => m.Reviews)
                                    .ToListAsync();
        }
    }
}
