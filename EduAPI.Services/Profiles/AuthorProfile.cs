namespace EduAPI.Services.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author,ReadAuthorDTO>();
        }
        
    }
}
