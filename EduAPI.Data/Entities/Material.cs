namespace EduAPI.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public MatType Type { get; set; }
        public int TypeId { get; set; }
        public DateTime PublishedAt { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

    }
}
