using BookStore.Core.DTOs.CategoryDTO;

namespace BookStore.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoriesGetterService
    {
        List<CategoryResponseDTO> GetAllCategories();

        CategoryResponseDTO GetCategoryByCategoryId(int categoryId);
    }
}
