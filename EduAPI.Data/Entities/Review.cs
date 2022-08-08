namespace EduAPI.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public string Contents { get; set; }
        public int Points { get; set; }

    }
}
