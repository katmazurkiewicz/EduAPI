using EduAPI.Data.Context;
using EduAPI.Data.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduAPI.Data.DAL.Repositories
{
    public class CudRepo<T> : ICudRepo<T> where T : class
    {
        protected EduContext _context;
        public CudRepo(EduContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
             _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        { 
            _context.Set<T>().Remove(entity);
        }
    }
}
