namespace EduAPI.Data.DAL.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        protected EduContext _context;
        public TypeRepository(EduContext context)
        {
            _context = context;
        }
        public async Task<MatType> GetSingleAsync(int id)
        {
            return await _context.Types.FindAsync(id);
        }
        public async Task<IEnumerable<MatType>> GetAllAsync()
        {
            return await _context.Types.ToListAsync();
        }
        public async Task<MatType> GetSingleWithDetailsAsync(int id)
        {
            return await _context.Types
                                  .Include(t => t.Materials)
                                  .Where(t => t.Id == id)
                                  .FirstOrDefaultAsync();
                
        }
    }
}
