using BookStore.Core.DTOs.ProductDTO;

namespace BookStore.Core.ServiceContracts.ProductContracts
{
    public interface IProductAdderService
    {
        ProductResponseDTO AddProduct(ProductAddRequestDTO? request);
    }
}
