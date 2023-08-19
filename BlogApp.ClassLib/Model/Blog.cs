using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ClassLib.Model
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

        public Blog(int id, string image, string description, string title, int userId)
        {
            Id = id;
            Image = image;
            Description = description;
            Title = title;
            UserId = userId;
        }
    }
}
