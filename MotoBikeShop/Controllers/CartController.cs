
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Controllers
{
	public class CartController : Controller
	{
		private readonly motoBikeVHDbContext db;
        //private readonly ICartService _cartService;
        public CartController(motoBikeVHDbContext context)
        {
            //, ICartService cartService
            //_cartService = cartService;
            db = context;
		}

		public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();

		public IActionResult Index()
		{
			return View(Cart);
		}

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.MaHH == id);
            if (item == null)
            {
                var hangHoa = db.HangHoas.SingleOrDefault(p => p.MaHH == id);
                if (hangHoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaHH = hangHoa.MaHH,
                    TenHH = hangHoa.TenHH,
                    DonGia = hangHoa.DonGia ?? 0,
                    Hinh = hangHoa.Hinh ?? string.Empty,
                    SoLuong = quantity
                };
                gioHang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
         

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
		{
			var gioHang = Cart;
			var item = gioHang.SingleOrDefault(p => p.MaHH == id);
			if (item != null)
			{
				gioHang.Remove(item);
				HttpContext.Session.Set(MySetting.CART_KEY, gioHang);
			}
			return RedirectToAction("Index");
		}
        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            if (Cart.Count == 0)
            {
                return Redirect("/");
            }

            return View(Cart);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(CheckoutVM model)
        {
            if (ModelState.IsValid)
            {
                var customerId = HttpContext.User.Claims.SingleOrDefault(p => p.Type == MySetting.CLAIM_CUSTOMERID).Value;
                var khachHang = new ApplicationUser();
                if (model.GiongKhachHang)
                {
                    //khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == customerId);
                    khachHang = db.Users.SingleOrDefault(kh=>kh.Id == customerId);
                }

                var hoadon = new HoaDon
                {
                    UserId = customerId,
                    HoTen = model.HoTen ?? khachHang.FullName,
                    DiaChi = model.DiaChi ?? khachHang.Address,
                    PhoneNumber = model.DienThoai ?? khachHang.PhoneNumber,
                    NgayDat = DateTime.Now,
                    CachThanhToan = "COD",
                    CachVanChuyen = "J&T",
                    MaTrangThai = 0,
                    GhiChu = model.GhiChu
                };

                db.Database.BeginTransaction();
                try
                {
                    db.Database.CommitTransaction();
                    db.Add(hoadon);
                    db.SaveChanges();

                    var cthds = new List<ChiTietHd>();
                    foreach (var item in Cart)
                    {
                        cthds.Add(new ChiTietHd
                        {
                            MaHD = hoadon.MaHD,
                            SoLuong = item.SoLuong,
                            DonGia = item.DonGia,
                            MaHH = item.MaHH,
                            GiamGia = 0
                        });
                    }
                    db.AddRange(cthds);
                    db.SaveChanges();

                    HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

                    return View("Success");
                }
                catch
                {
                    db.Database.RollbackTransaction();
                }
            }

            return View(Cart);
        }
        //[HttpPost]
        //public IActionResult UpdateQuantity(int id, int quantity)
        //{
        //    // Tìm sản phẩm trong giỏ hàng dựa trên id
        //    var cartItem = _cartService.FindCartItemById(id);

        //    if (cartItem == null)
        //    {
        //        return Json(new { success = false, message = "Sản phẩm không tồn tại trong giỏ hàng." });
        //    }

        //    // Kiểm tra xem số lượng mới có hợp lệ hay không
        //    if (quantity < 1 || quantity > cartItem.SoLuong)
        //    {
        //        return Json(new { success = false, message = "Số lượng không hợp lệ." });
        //    }

        //    // Cập nhật số lượng sản phẩm
        //    cartItem.SoLuong = quantity;

        //    // Lưu thay đổi vào cơ sở dữ liệu hoặc quản lý giỏ hàng của bạn

        //    // Trả về kết quả thành công
        //    return Json(new { success = true });
        //}

    }
}
