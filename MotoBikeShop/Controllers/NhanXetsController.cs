using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoBikeShop.Data;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;

namespace MotoBikeShop.Controllers
{
	public class NhanXetsController : Controller
	{
private readonly IReviewRepository _reviewRepository;


		public NhanXetsController(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;	
		}
		public async Task<IActionResult> Index()
		{
			var reviews = await _reviewRepository.GetAllAsync();
			return View(reviews);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var reviews = await _reviewRepository.GetAllAsync();
			if (reviews == null)
			{
				reviews = new List<NhanXet>(); // khởi tạo một danh sách rỗng nếu loais là null
			}
			ViewBag.Loais = new SelectList(reviews, "HoTen", "HoTen");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(NhanXet nhanXet)
		{
			if (ModelState.IsValid)
			{
				
				await _reviewRepository.AddAsync(nhanXet);
				return RedirectToAction(nameof(Index));
			}
			return View(nhanXet);
		}
	}
}
