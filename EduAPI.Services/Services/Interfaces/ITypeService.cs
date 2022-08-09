using EduAPI.Services.Models.DTOs;

namespace EduAPI.Services.Interfaces
{
    public interface ITypeService
    {
        public  Task<ReadTypeDTO> GetSingleAsync(int id);
        public  Task<IEnumerable<ReadTypeDTO>> GetAllAsync();
        public  Task<IEnumerable<ReadMaterialDTO>> GetTypeMaterialsAsync(int id);
        
    }
}
