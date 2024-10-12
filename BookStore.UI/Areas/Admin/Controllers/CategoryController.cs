using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Core.ServiceContracts.CategoryContracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoriesAdderService _categoriesAdderService;
        private readonly ICategoriesGetterService _categoriesGetterService;
        private readonly ICategoryUpdaterService _categoryUpdaterService;
        private readonly ICategoryDeleterService _categoryDeleterService;

        public CategoryController(
            ICategoriesAdderService categoriesAdderService,
            ICategoriesGetterService categoriesGetterService,
            ICategoryUpdaterService categoryUpdaterService,
            ICategoryDeleterService categoryDeleterService
            )
        {
            _categoriesAdderService = categoriesAdderService;
            _categoriesGetterService = categoriesGetterService;
            _categoryUpdaterService = categoryUpdaterService;
            _categoryDeleterService = categoryDeleterService;
        }
        public IActionResult Index()
        {
            List<CategoryResponseDTO> categories = _categoriesGetterService.GetAllCategories().ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryAddRequestDTO request)
        {
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(category);
                //_db.SaveChanges();
                _categoriesAdderService.AddCategroy(request);
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentNullException("id should be greater than 0");


            CategoryResponseDTO category = _categoriesGetterService.GetCategoryByCategoryId(categoryId);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryUpdateDTO request)
        {
            if (ModelState.IsValid)
            {
                if (_categoryUpdaterService.UpdateCategory(request)) TempData["success"] = "Category updated successfully";
                if (!_categoryUpdaterService.UpdateCategory(request)) TempData["error"] = "Category updated unsuccessfully";

                return RedirectToAction("Index");
            }

            if (request == null) throw new ArgumentNullException(nameof(request));

            if (request.CategoryId <= 0) return NotFound();

            CategoryResponseDTO category = _categoriesGetterService.GetCategoryByCategoryId(request.CategoryId);
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int categoryId)
        {
            if (categoryId <= 0) return NotFound();

            CategoryResponseDTO category = _categoriesGetterService.GetCategoryByCategoryId(categoryId);

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(CategoryUpdateDTO request)
        {
            if (ModelState.IsValid)
            {
                _categoryDeleterService.DeleteCategory(request.CategoryId);
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            }
            CategoryResponseDTO category = _categoriesGetterService.GetCategoryByCategoryId(request.CategoryId);
            return View(category);
        }
    }
}