namespace EduAPI.Services.Profiles
{
    public class MaterialProfile:Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, ReadMaterialDTO>();
            CreateMap<WriteMaterialDTO, Material>();
        }
            
    }
}
