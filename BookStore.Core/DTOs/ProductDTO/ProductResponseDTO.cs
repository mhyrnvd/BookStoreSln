
using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Domain.Entities;
using BookStore.Domain.Models;

namespace BookStore.Core.DTOs.ProductDTO
{
    public class ProductResponseDTO
    {
        public int ProductId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        
        public string ISBN { get; set; }
        public string Author { get; set; }

        public double ListPrice { get; set; }


        public double Price { get; set; }

        public double Price50 { get; set; }

        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

    }
    public static class ProductExtensions
    {
        public static ProductResponseDTO ToProductResponse(this Product product)
        {
            return new ProductResponseDTO
            {
                ProductId = product.ProductId,
                Title = product.Title,
                Description = product.Description,
                ISBN = product.ISBN,
                Author = product.Author,
                ListPrice = product.ListPrice,
                Price = product.Price,
                Price50 = product.Price50,
                Price100 = product.Price100,
                CategoryId = product.Category.CategoryId,
                CategoryName = product.Category.Name,
                ImageUrl = product.ImageUrl,
            };
        }
    }
}
