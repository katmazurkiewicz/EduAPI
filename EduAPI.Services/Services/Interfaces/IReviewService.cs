namespace EduAPI.Services.Interfaces
{
    public interface IReviewService
    {
        public Task<ReadReviewDTO> GetSingleAsync(int id);
        public Task<IEnumerable<ReadReviewDTO>> GetAllAsync();

        public Task<ReadReviewDTO> CreateAsync(WriteReviewDTO dto);

        public Task UpdateAsync(int id, WriteReviewDTO dto);

        public Task DeleteAsync(int id);
    }
}
