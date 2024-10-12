using BookStore.Core.DTOs.CategoryDTO;

namespace BookStore.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryUpdaterService
    {
        bool UpdateCategory(CategoryUpdateDTO? request);
    }
}
