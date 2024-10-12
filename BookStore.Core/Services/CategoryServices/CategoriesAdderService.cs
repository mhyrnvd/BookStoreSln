using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Core.Helpers;
using BookStore.Core.RepositoryContracts;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Domain.Models;

namespace BookStore.Core.Services.CategoryServices
{
    public class CategoriesAdderService : ICategoriesAdderService
    {
        private readonly IUnitOfWork _uow;
        public CategoriesAdderService(IUnitOfWork categoriesRepository)
        {
            _uow = categoriesRepository;
        }
        public CategoryResponseDTO AddCategroy(CategoryAddRequestDTO? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            ValidatorHelper.ModelValidation(request);

            Category category = request.ToCategory();

            _uow.Categories.Add(category);
            _uow.Save();

            return category.ToCategoryResponse();
        }
    }
}
