using BookStore.Core.DTOs.CategoryDTO;

namespace BookStore.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoriesAdderService
    {
        CategoryResponseDTO AddCategroy(CategoryAddRequestDTO? request);
    }
}
