using System.ComponentModel.DataAnnotations;

namespace EduAPI.Services.Models.DTOs
{
    public class WriteReviewDTO
    {
        [Required]
        public int MaterialId { get; set; }
        [Required]
        [MinLength(3), MaxLength(150)]
        public string Contents { get; set; }
        [Required]
        [Range(1,10)]
        public int Points { get; set; }
    }
}
