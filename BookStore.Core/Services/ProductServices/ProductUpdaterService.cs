using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Core.DTOs.ProductDTO;
using BookStore.Core.Helpers;
using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Core.ServiceContracts.ProductContracts;
using BookStore.Domain.Entities;
using BookStore.Domain.Models;

namespace BookStore.Core.Services.ProductServices
{
    public class ProductUpdaterService : IProductUpdaterService
    {
        private readonly IUnitOfWork _ouw;

        public ProductUpdaterService(IUnitOfWork repo)
        {
            _ouw = repo;
        }
        public bool UpdateProduct(ProductUpdateDTO? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.ProductId <= 0) throw new ArgumentException("The id should be greater than 0");

            ValidatorHelper.ModelValidation(request);

            Product? product = _ouw.Products.GetById(u => u.ProductId == request.ProductId);
            product.Category = _ouw.Categories.GetById(u => u.CategoryId == product.CategoryId);

            if (product == null) throw new Exception("there isn't any product for this id");
            product.Title = request.Title;
            product.Description = request.Description;
            product.Author = request.Author;
            product.Price = request.Price;
            product.ListPrice = request.ListPrice;
            product.Price50 = request.Price50;
            product.Price100 = request.Price100;
            product.CategoryId = request.CategoryId;

            _ouw.Products.Update(product);

            return _ouw.Save();
        }
    }
}
