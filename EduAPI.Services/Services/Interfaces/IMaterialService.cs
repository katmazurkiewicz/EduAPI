using EduAPI.Services.Models.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace EduAPI.Services.Interfaces
{
    public interface IMaterialService
    {
        public Task<ReadMaterialDTO> GetSingleAsync(int id);
        public Task<IEnumerable<ReadMaterialDTO>> GetAllAsync();

        public Task<ReadMaterialDTO> CreateAsync(WriteMaterialDTO dto);

        public Task UpdateAsync(int id, JsonPatchDocument materialPatch);

        public Task DeleteAsync(int id);
        
    }
}
