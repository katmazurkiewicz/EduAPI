using EduAPI.Services.Models.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace EduAPI.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<ReadReviewDTO> GetSingleAsync(int id);
        public Task<IEnumerable<ReadReviewDTO>> GetAllAsync();

        public Task<ReadReviewDTO> CreateAsync(WriteReviewDTO dto);

        public Task UpdateAsync(int id, JsonPatchDocument materialPatch);

        public Task DeleteAsync(int id);
    }
}
