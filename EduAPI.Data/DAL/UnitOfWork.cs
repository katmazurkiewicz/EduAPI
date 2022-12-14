namespace EduAPI.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EduContext _context;

        public IAuthorRepository Authors { get; }
        public IMaterialRepository Materials { get; }
        public ITypeRepository Types { get; }
        public IReviewRepository Reviews { get; }

        public UnitOfWork(EduContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            Materials = new MaterialRepository(_context);
            Types = new TypeRepository(_context);
            Reviews = new ReviewRepository(_context);
        }

        public async Task<int> CompleteUnitAsync()
            => await _context.SaveChangesAsync();
    }
}
