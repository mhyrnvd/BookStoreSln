using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookStore.Core.RepositoryContracts.CategoryRepoContract;
using BookStore.Core.RepositoryContracts.ProductRepoContract;

namespace BookStore.Core.RepositoryContracts
{
    public interface IUnitOfWork
    {
        ICategoriesRepository Categories { get; }
        IProductsRepository Products { get; }
        bool Save();
    }
}
