namespace EduAPI.Data.DAL.Interfaces
{
    public interface ITypeRepository : IReadRepo<MatType>
    {
        public Task<MatType> GetSingleWithDetailsAsync(int id);
    }
}
