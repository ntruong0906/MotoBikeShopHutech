using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;

namespace MotoBikeShop.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class HangHoasController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFactoryRepository _factoryRepository;

        public HangHoasController(IProductRepository productRepository, ICategoryRepository categoryRepository, IFactoryRepository factoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _factoryRepository = factoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _productRepository.GetAllAsync();
            return View(product);
        }
        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Add(HangHoa product, IFormFile imageUrl)
        {
            if (ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện tham khảo bài 02 hàm SaveImage
                    product.Hinh =  MyUtil.SaveImage(imageUrl);
                }
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }
        
    }
}