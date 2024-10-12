using BookStore.Core.RepositoryContracts.CategoryRepoContract;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repository.CategoryRepo
{
    public class CategoryRepository : CommonRepository<Category>, ICategoriesRepository
    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
        }
        #region OlderVersion
        //public readonly ApplicationDbContext _db;

        //public CategoryRepository(ApplicationDbContext db)
        //{
        //    _db = db;
        //}
        //public void AddCategory(Category category)
        //{
        //    _db.Categories.Add(category);
        //    _db.SaveChanges();
        //}

        //public bool DeleteCategory(int categoryId)
        //{
        //    Category? category = _db.Categories.FirstOrDefault(u => u.CategoryId == categoryId);
        //    if (category == null) return false;

        //    _db.Categories.Remove(category);
        //    _db.SaveChanges();

        //    return true;
        //}

        //public List<Category> GetCategories()
        //{
        //    return _db.Categories.ToList();
        //}

        //public Category? GetCategoryByCategoryId(int categoryId)
        //{
        //    Category? category = _db.Categories.FirstOrDefault(u  => u.CategoryId == categoryId);
        //    return category;
        //}

        //public bool UpdateCategory(Category category)
        //{
        //    _db.Categories.Update(category);
        //    return _db.SaveChanges() > 0;
        //}
        #endregion
    }
}
