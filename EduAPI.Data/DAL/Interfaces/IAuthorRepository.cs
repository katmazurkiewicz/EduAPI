using EduAPI.Data.Context;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduAPI.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IReadRepo<Author>
        {
            public Task<Author> GetSingleAsync(int id);
            public Task<IEnumerable<Author>> GetAllAsync();
            public Task<IEnumerable<Material>> GetTopMaterialsAsync(int id);
            public Task<IEnumerable<Author>> GetMostProductiveAsync();
            
        }
}

