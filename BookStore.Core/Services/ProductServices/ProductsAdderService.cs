using BookStore.Core.DTOs.ProductDTO;
using BookStore.Core.Helpers;
using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.ProductContracts;
using BookStore.Domain.Entities;

namespace BookStore.Core.Services.ProductsServices
{
    public class ProductsAdderService : IProductAdderService
    {
        private readonly IUnitOfWork _uow;
        public ProductsAdderService(IUnitOfWork repository)
        {
            _uow = repository;
        }
        public ProductResponseDTO AddProduct(ProductAddRequestDTO? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidatorHelper.ModelValidation(request);

            Product product = request.ToProduct();
            product.Category = _uow.Categories.GetById(u => u.CategoryId == product.CategoryId);
            _uow.Products.Add(product);
            _uow.Save();

            return product.ToProductResponse();
        }
    }
}
