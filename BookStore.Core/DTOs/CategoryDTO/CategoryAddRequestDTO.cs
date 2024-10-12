using BookStore.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.DTOs.CategoryDTO
{
    public class CategoryAddRequestDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int DisplayOrder { get; set; }

        public Category ToCategory()
        {
            return new Category { Name = Name, DisplayOrder = DisplayOrder };
        }
    }
}
