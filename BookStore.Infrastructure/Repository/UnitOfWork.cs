using BookStore.Core.RepositoryContracts;
using BookStore.Core.RepositoryContracts.CategoryRepoContract;
using BookStore.Core.RepositoryContracts.ProductRepoContract;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repository.CategoryRepo;
using BookStore.Infrastructure.Repository.ProductRepo;


namespace BookStore.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        private ICategoriesRepository? _categories;
        public ICategoriesRepository Categories
        {
            get
            {
                if (_categories == null)
                    _categories = new CategoryRepository(_context);
                return _categories;
            }
        }

        private IProductsRepository? _product;
        public IProductsRepository Products
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(_context);
                return _product;
            }
        }


        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
