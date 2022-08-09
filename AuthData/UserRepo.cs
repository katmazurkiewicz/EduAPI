namespace AuthData
{
    public class UserRepo
    {
        protected AuthContext _context;
        public UserRepo(AuthContext context)
        {
            _context = context;
        }
        public User GetSingle(string username)
        {
            return  _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        
    }
}
