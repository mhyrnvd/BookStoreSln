using BookStore.Domain.Entities;

namespace BookStore.Core.RepositoryContracts.ProductRepoContract
{
    public interface IProductsRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAllWithCategory();
    }
}
