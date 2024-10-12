using BookStore.Core.DTOs.CategoryDTO;
using BookStore.Core.DTOs.ProductDTO;
using BookStore.Core.ServiceContracts.CategoryContracts;
using BookStore.Core.ServiceContracts.ProductContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAdderService _productAdderService;
        private readonly IProductGetterService _productGetterService;
        private readonly IProductUpdaterService _productUpdaterService;
        private readonly IProductDeleterService _productDeleterService;
        private readonly ICategoriesGetterService _categoriesGetterService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(
            IProductAdderService productAdderService,
            IProductGetterService productGetterService,
            IProductUpdaterService productUpdaterService,
            IProductDeleterService productDeleterService,
            ICategoriesGetterService categoriesGetterService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _productAdderService = productAdderService;
            _productGetterService = productGetterService;
            _productUpdaterService = productUpdaterService;
            _productDeleterService = productDeleterService;
            _categoriesGetterService = categoriesGetterService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<ProductResponseDTO> products = _productGetterService.GetAllProducts().ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _categoriesGetterService.GetAllCategories().Select(u =>
                new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }
            );
            ViewBag.CategoryList = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductAddRequestDTO request, IFormFile? file)
        {
            if (file == null)
            {
                ModelState.AddModelError("file", "Please upload an image.");
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    request.ImageUrl = @"images\product\" + fileName;
                }
                _productAdderService.AddProduct(request);
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            if (productId <= 0) throw new ArgumentNullException("id should be greater than 0");

            IEnumerable<SelectListItem> CategoryList = _categoriesGetterService.GetAllCategories().Select(u =>
                new SelectListItem
                {
                    Text = u.Name,
                    Value = u.CategoryId.ToString()
                }
            );
            ViewBag.CategoryList = CategoryList;
            ProductResponseDTO product = _productGetterService.GetProductByProductId(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductUpdateDTO request)
        {
            if (ModelState.IsValid)
            {
                bool status = _productUpdaterService.UpdateProduct(request);
                if (status) TempData["success"] = "Product updated successfully";
                if (!status) TempData["error"] = "Product updated unsuccessfully";

                return RedirectToAction("Index", "Product");
            }

            if (request == null) throw new ArgumentNullException(nameof(request));

            if (request.ProductId <= 0) return NotFound();

            ProductResponseDTO product = _productGetterService.GetProductByProductId(request.ProductId);
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int productId)
        {
            if (productId <= 0) return NotFound();

            ProductResponseDTO product = _productGetterService.GetProductByProductId(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(ProductUpdateDTO request)
        {
            if (ModelState.IsValid)
            {
                _productDeleterService.DeleteProduct(request.ProductId);
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction("Index", "Product");
            }
            ProductResponseDTO product = _productGetterService.GetProductByProductId(request.ProductId);
            return View(product);
        }
    }
}
