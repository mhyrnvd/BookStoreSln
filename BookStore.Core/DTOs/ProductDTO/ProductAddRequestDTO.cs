using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.DTOs.ProductDTO
{
    public class ProductAddRequestDTO
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }


        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId  { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        public Product ToProduct()
        {
            return new Product 
            { 
                Title = Title,
                Description = Description,
                ISBN = ISBN,
                Author = Author,
                ListPrice = ListPrice,
                Price = Price, 
                Price50 = Price50, 
                Price100 = Price100 ,
                CategoryId = CategoryId,
                ImageUrl = ImageUrl
            };
        }
    }
}
