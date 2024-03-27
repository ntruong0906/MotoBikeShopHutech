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
        public async Task<IActionResult> Create()
        {
            var loais = await _categoryRepository.GetAllAsync();
            if (loais == null)
            {
                loais = new List<Loai>(); // khởi tạo một danh sách rỗng nếu loais là null
            }
            ViewBag.Loais = new SelectList(loais, "Id", "Name");

            var nhaCungCaps = await _factoryRepository.GetAllAsync();
            if (nhaCungCaps == null)
            {
                nhaCungCaps = new List<NhaCungCap>(); // khởi tạo một danh sách rỗng nếu nhaCungCaps là null
            }
            ViewBag.NhaCungCaps = new SelectList(nhaCungCaps, "Id", "Name");

            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        public async Task<IActionResult> Create(HangHoa product, IFormFile imageUrl)
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