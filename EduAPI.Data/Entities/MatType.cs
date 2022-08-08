namespace EduAPI.Data.Entities
{
    public class MatType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public IEnumerable<Material> Materials { get; set; }
    }
}
