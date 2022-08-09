using System.ComponentModel.DataAnnotations;

namespace EduAPI.Services.Models.DTOs
{
    public class WriteMaterialDTO
    {
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int TypeId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

    }
}
