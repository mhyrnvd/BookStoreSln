using BookStore.Domain.Models;

namespace BookStore.Core.DTOs.CategoryDTO
{
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }

    public static class CategoryExtensions
    {
        public static CategoryResponseDTO ToCategoryResponse(this Category category)
        {
            return new CategoryResponseDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder
            };
        }
    }
}
