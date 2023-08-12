using System.ComponentModel.DataAnnotations;

namespace BlogWebApi.Model
{
    public class Blog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
