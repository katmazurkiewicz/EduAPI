namespace EduAPI.Data.DAL.Repositories
{
    public class MaterialRepository: IMaterialRepository
    {
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
