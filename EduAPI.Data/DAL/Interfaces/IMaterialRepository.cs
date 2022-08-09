using EduAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduAPI.Data.DAL.Interfaces
{
    public interface IMaterialRepository: IReadRepo<Material>, ICudRepo<Material>
    {
        //public void Add(Material entity);
       // public void Update(Material entity);
       // public void Delete(Material entity);
       public Task<Material> GetSingleAsync(int id);
       public Task<IEnumerable<Material>> GetAllAsync();
    }
}
