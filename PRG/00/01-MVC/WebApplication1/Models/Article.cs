using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }
        [Required]
        public bool Published { get; set; }
    }
}
