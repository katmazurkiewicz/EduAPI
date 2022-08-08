namespace EduAPI.Data.DAL.Interfaces
{
    public interface ICudRepo<T> where T : class
    {
        public void Add(T entity);   
        public void Update(T entity);
        public void Delete(T entity);
    }
}