using BookStore.Core.DTOs.ProductDTO;

namespace BookStore.Core.ServiceContracts.ProductContracts
{
    public interface IProductGetterService
    {
        List<ProductResponseDTO> GetAllProducts();

        ProductResponseDTO GetProductByProductId(int productId);
    }
}
