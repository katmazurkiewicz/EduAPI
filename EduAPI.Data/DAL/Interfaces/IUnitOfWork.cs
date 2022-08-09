using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduAPI.Data.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IAuthorRepository Authors { get; }
        public IMaterialRepository Materials { get; }
        public ITypeRepository Types { get; }
        public IReviewRepository Reviews { get; }

        public  Task<int> CompleteUnitAsync();
    }
}
