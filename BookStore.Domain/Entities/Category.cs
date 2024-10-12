using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int DisplayOrder { get; set; }
    }
}
