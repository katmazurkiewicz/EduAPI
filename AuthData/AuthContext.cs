using Microsoft.EntityFrameworkCore;


namespace AuthData
{
    public class AuthContext : DbContext

    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        { }
        
        public DbSet<User> Users { get; set; }
    }
}
