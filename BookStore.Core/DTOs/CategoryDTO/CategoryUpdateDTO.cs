using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DTOs.CategoryDTO
{
    public class CategoryUpdateDTO
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int DisplayOrder { get; set; }
    }
}
