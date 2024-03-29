using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using System.Collections.Generic;
using System.Linq;

namespace MotoBikeShop.ViewComponents
{
	public class SanPhamTTViewComponent : ViewComponent
	{
		private readonly motoBikeVHDbContext db;

		public SanPhamTTViewComponent(motoBikeVHDbContext context) => db = context;

        public IViewComponentResult Invoke(int maloai)
        {
            // Lấy danh sách sản phẩm có cùng mã loại
            var products = GetProductsByMaloai(maloai);

            // Trả về view và truyền danh sách sản phẩm
            return View(products);
        }

        public List<HangHoa> GetProductsByMaloai(int maloai)
        {
            return db.HangHoas.Where(p => p.MaLoai == maloai).ToList();
        }
    }
}