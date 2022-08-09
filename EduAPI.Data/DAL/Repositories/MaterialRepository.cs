using EduAPI.Data.Context;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduAPI.Data.DAL.Repositories
{
    public class MaterialRepository: IMaterialRepository
    {
        //public MaterialRepository(EduContext context) : base(context)
        //{}
        protected EduContext _context;
        public MaterialRepository (EduContext context)
        {
            _context = context;
        }
        public void Add(Material material)
        {
            _context.Materials.Add(material);
        }


        public void Update(Material material)
        {
            _context.Materials.Update(material);
        }

        public void Delete(Material material)
        {
            _context.Materials.Remove(material);
        }
        public async Task<Material> GetSingleAsync(int id)
        {
            return await _context.Materials.FindAsync(id);
        }
        public async Task<IEnumerable<Material>> GetAllAsync()
        {
            return await _context.Materials.ToListAsync();
        }
    }
}
