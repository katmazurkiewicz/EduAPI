namespace EduAPI.Data.DAL.Interfaces
{
    public interface IReadRepo<T> where T : class
    {
        public Task<T> GetSingleAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}