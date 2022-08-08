using EduAPI.Services.Models.DTOs;

namespace EduAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<ReadAuthorDTO> GetSingleAsync(int id);
        Task<IEnumerable<ReadAuthorDTO>> GetAllAsync();

        //Task<IEnumerable<ReadMaterialDTO>> GetTopMaterialsAsync(int id);

        Task<IEnumerable<ReadAuthorDTO>> GetMostProductiveAsync();
    }
}
