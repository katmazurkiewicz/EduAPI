namespace EduAPI.Services.Profiles
{
    public class TypeProfile:Profile
    {
        public TypeProfile()
        {
            CreateMap<MatType, ReadTypeDTO>();
        }

    }
}
