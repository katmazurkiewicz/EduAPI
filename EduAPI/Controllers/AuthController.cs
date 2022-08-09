namespace EduAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserRepo _userRepo;
        
        public AuthController(IConfiguration configuration, AuthContext context)
        {
            _configuration = configuration;
            _userRepo = new(context);
        }
        [HttpPost("register")]
        [Authorize(Roles="admin")]
        public async Task<ActionResult<User>> RegisterAdmin(UserDTO request)
        {   
            var test = _userRepo.GetSingle(request.Username);
            if (test != null)
                return BadRequest("Username already exists");
            var admin = new User();
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            admin.Username = request.Username;
            admin.PasswordHash = passwordHash;
            admin.PasswordSalt = passwordSalt;
            admin.Role = "admin";
            _userRepo.Create(admin);
            return Ok(admin);
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var test = _userRepo.GetSingle(request.Username);
            if (test.Username != request.Username)
            {
                return BadRequest("User not found");
            }
            
            if (!VerifyPasswordHash(test, request.Password, test.PasswordHash, test.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }
            string token = CreateToken(test);
            return Ok(token);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(User user, string password, byte[] passwordHash, byte[] passwordSalt)
        {
            
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
