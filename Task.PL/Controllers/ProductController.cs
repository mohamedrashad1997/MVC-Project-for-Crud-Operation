using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Task.BLL.Interfaces;
using Task.DAL.Entities;
using Task.PL.Models;

namespace Task.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;          
        }

        public IActionResult Index()
        {
            var products = _productRepository.Read();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.Read();
            return View(new ProductViewModel());
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductName = productViewModel.ProductName,
                    ProductDescription = productViewModel.ProductDescription,
                    ProductPrice = productViewModel.ProductPrice,
                    ProductQuantity = productViewModel.ProductQuantity,
                    CategoryID = productViewModel.CategoryID,

                };
                    _productRepository.Add(product);
                    TempData["Message"] = "Product Created Successfully!";
                    return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        public IActionResult Update(int? id)
        {
            ViewBag.Categories = _categoryRepository.Read();
            if (id == null)
                return BadRequest();

                var product = _productRepository.GetById(id.Value);
                ProductViewModel productViewModel = new()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = product.ProductQuantity,
                    CategoryID = product.CategoryID,
                };

            if (productViewModel is null)
                return NotFound();

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new()
                    {
                        ProductId = productViewModel.ProductId,
                        ProductName = productViewModel.ProductName,
                        ProductDescription = productViewModel.ProductDescription,
                        ProductPrice = productViewModel.ProductPrice,
                        ProductQuantity = productViewModel.ProductQuantity,
                        CategoryID = productViewModel.CategoryID,
                    };
                        _productRepository.Update(product);
                        TempData["Message"] = "Product Updated Successfully!";
                        return RedirectToAction(nameof(Index));
                }
                catch(System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return RedirectToAction(nameof(Index));
            try
            {
                _productRepository.Delete(id);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            TempData["Message"] = "Product Deleted Successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
