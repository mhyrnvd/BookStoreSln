using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Core.Helpers;
using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Domain.Models;

namespace BookStore.Core.Services.CategoryServices
{
    public class CategoryUpdaterService : ICategoryUpdaterService
    {
        private readonly IUnitOfWork _ouw;

        public CategoryUpdaterService(IUnitOfWork categoriesRepository)
        {
            _ouw = categoriesRepository;
        }
        public bool UpdateCategory(CategoryUpdateDTO? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.CategoryId <= 0) throw new ArgumentException("The id should be greater than 0");

            ValidatorHelper.ModelValidation(request);

            Category? category = _ouw.Categories.GetById(u => u.CategoryId == request.CategoryId);

            if (category == null) throw new Exception("there isn't any category for this id");
            category.Name = request.Name;
            category.DisplayOrder = request.DisplayOrder;
            _ouw.Categories.Update(category);

            return _ouw.Save();
        }
    }
}
