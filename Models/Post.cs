using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PostModel
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
