using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.Models;

namespace MotoBikeShop.ViewComponents
{
	public class NhanXetViewComponent : ViewComponent
	{
		private readonly motoBikeVHDbContext db;

		public NhanXetViewComponent(motoBikeVHDbContext context) => db = context;

		public IViewComponentResult Invoke()
		{
			// Lấy danh sách tất cả Nhận Xet
			var products = GetReview();

			// Trả về view và truyền danh sách sản phẩm
			return View(products);
		}

		public List<NhanXet> GetReview()
		{
			return db.NhanXets.ToList();
		}
	}
}
