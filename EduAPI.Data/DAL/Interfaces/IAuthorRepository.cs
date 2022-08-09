namespace EduAPI.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IReadRepo<Author>
    {
        public Task<Author> GetSingleWithDetailsAsync(int id);
        public Task<IEnumerable<Author>> GetAllWithDetailsAsync();
    }
}

