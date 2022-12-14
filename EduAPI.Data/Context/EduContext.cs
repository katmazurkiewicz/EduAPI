namespace EduAPI.Data.Context
{
    public class EduContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MatType> Types { get; set; }
        public EduContext(DbContextOptions<EduContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }
    }
}
