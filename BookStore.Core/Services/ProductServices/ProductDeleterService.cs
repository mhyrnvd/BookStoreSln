using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Core.ServiceContracts.ProductContracts;
using BookStore.Domain.Entities;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Services.ProductServices
{
    public class ProductsDeleterService : IProductDeleterService
    {
        private readonly IUnitOfWork _ouw;

        public ProductsDeleterService(IUnitOfWork repository)
        {
            _ouw = repository;   
        }
        public bool DeleteProduct(int id)
        {
            if (id <= 0) throw new ArgumentException("the id should be greater than 0");

            Product? product = _ouw.Products.GetById(u => u.ProductId == id);

            if (product == null) throw new Exception("there isn't any Product with this id");
            _ouw.Products.Remove(product);

            return _ouw.Save();
        }
    }
}
