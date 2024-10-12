using BookStore.Core.RepositoryContracts.ProductRepoContract;
using BookStore.Domain.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repository.ProductRepo
{
    public class ProductRepository : CommonRepository<Product>, IProductsRepository
    {
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
        }
        public IEnumerable<Product> GetAllWithCategory()
        {
            return _db.Set<Product>()
                .Include(p => p.Category)
                .ToList();
        }
    }
}
