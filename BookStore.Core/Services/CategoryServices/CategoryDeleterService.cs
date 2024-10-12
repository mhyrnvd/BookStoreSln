using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Domain.Models;

namespace BookStore.Core.Services.CategoryServices
{
    public class CategoryDeleterService : ICategoryDeleterService
    {
        private readonly IUnitOfWork _ouw;

        public CategoryDeleterService(IUnitOfWork categoriesRepository)
        {
            _ouw = categoriesRepository;   
        }
        public bool DeleteCategory(int id)
        {
            if (id <= 0) throw new ArgumentException("the id should be greater than 0");

            Category? category = _ouw.Categories.GetById(u => u.CategoryId == id);

            if (category == null) throw new Exception("there isn't any category with this id");
            _ouw.Categories.Remove(category);

            return _ouw.Save();
        }
    }
}
