using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Services.CategoryServices
{
    public class CategoriesGetterService : ICategoriesGetterService
    {
        private readonly IUnitOfWork _uow;

        public CategoriesGetterService(IUnitOfWork categoriesRepository)
        {
            _uow = categoriesRepository;
        }
        public List<CategoryResponseDTO> GetAllCategories()
        {
            return _uow.Categories.GetAll().Select(x => x.ToCategoryResponse()).ToList();
        }

        public CategoryResponseDTO GetCategoryByCategoryId(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException("the id should greater than 0");

            Category? category = _uow.Categories.GetById(u => u.CategoryId == categoryId);
            if (category == null) throw new Exception("there isn't any category with this id");

            return category.ToCategoryResponse();
        }
    }
}
