using BookStore.Core.DTOs.ProductDTO;

namespace BookStore.Core.ServiceContracts.ProductContracts
{
    public interface IProductUpdaterService
    {
        bool UpdateProduct(ProductUpdateDTO? request);
    }
}
