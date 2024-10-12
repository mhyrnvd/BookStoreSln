using BookStore.Core.DTOs.ProductDTO;
using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.ProductContracts;
using BookStore.Domain.Entities;

namespace BookStore.Core.Services.ProductServices
{
    public class ProductsGetterService : IProductGetterService
    {
        private readonly IUnitOfWork _uow;

        public ProductsGetterService(IUnitOfWork repository)
        {
            _uow = repository;
        }
        public List<ProductResponseDTO> GetAllProducts()
        {
            var products = _uow.Products.GetAll().ToList();

            // Convert each product to ProductResponseDTO
            var productResponseDTOs = products.Select(product =>
            {
                // Fetch the corresponding category for each product
                product.Category = _uow.Categories.GetById(u => u.CategoryId == product.CategoryId);

                // Use the extension method ToProductResponse() to map the product to ProductResponseDTO
                return product.ToProductResponse();
            }).ToList();

            return productResponseDTOs; ;
        }

        public ProductResponseDTO GetProductByProductId(int productId)
        {
            if (productId <= 0) throw new ArgumentOutOfRangeException("the id should greater than 0");

            Product? product = _uow.Products.GetById(u => u.ProductId == productId);
            product.Category = _uow.Categories.GetById(u => u.CategoryId == product.CategoryId);
            if (product == null) throw new Exception("there isn't any product with this id");

            return product.ToProductResponse();
        }
    }
}
