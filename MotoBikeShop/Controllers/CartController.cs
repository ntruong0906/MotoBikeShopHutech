
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;
using System.Security.Claims;

namespace MotoBikeShop.Controllers
{
	public class CartController : Controller
	{
		private readonly motoBikeVHDbContext db;
        private readonly UserManager<ApplicationUser> _userManager;

        //private readonly ICartService _cartService;
        public CartController(motoBikeVHDbContext context, UserManager<ApplicationUser> userManager)
        {
            //, ICartService cartService
            //_cartService = cartService;
            db = context;
            _userManager = userManager;
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
                var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var khachHang = new ApplicationUser();
                if (model.GiongKhachHang)
                {
                    khachHang = db.Users.SingleOrDefault(kh => kh.Id == customerId);
                }

                var hoadon = new HoaDon
                {
                    UserId = customerId,
                    HoTen = model.HoTen ?? khachHang.FullName,
                    DiaChi = model.DiaChi ?? khachHang.Address,
                    PhoneNumber = model.DienThoai ?? khachHang.PhoneNumber,
                    NgayDat = DateTime.Now,
					NgayGiao = DateTime.Now.AddDays(3),
					CachThanhToan = "COD",
                    CachVanChuyen = "J&T",
                    MaTrangThai = 1,
                    GhiChu = model.GhiChu,
                    PhiVanChuyen = 30.0000,
                };

                db.Database.BeginTransaction();
                try
                {
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

                    db.Database.CommitTransaction();

                    HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

                    return View("Success");
                }
                catch
                {
                    return View("Error");
                    db.Database.RollbackTransaction();
                }
            }

            return View(Cart);
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
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
		//[Authorize]
		//public IActionResult PaymentSuccess()
		//{
		//	return View("Success");
		//}

		//[Authorize]
		//[HttpPost("/Cart/create-paypal-order")]
		//public async Task<IActionResult> CreatePaypalOrder(CancellationToken cancellationToken)
		//{
		//	// Thông tin đơn hàng gửi qua Paypal
		//	var tongTien = Cart.Sum(p => p.ThanhTien).ToString();
		//	var donViTienTe = "USD";
		//	var maDonHangThamChieu = "DH" + DateTime.Now.Ticks.ToString();

		//	try
		//	{
		//		var response = await _paypalClient.CreateOrder(tongTien, donViTienTe, maDonHangThamChieu);

		//		return Ok(response);
		//	}
		//	catch (Exception ex)
		//	{
		//		var error = new { ex.GetBaseException().Message };
		//		return BadRequest(error);
		//	}
		//}

		//[Authorize]
		//[HttpPost("/Cart/capture-paypal-order")]
		//public async Task<IActionResult> CapturePaypalOrder(string orderID, CancellationToken cancellationToken)
		//{
		//	try
		//	{
		//		var response = await _paypalClient.CaptureOrder(orderID);

		//		// Lưu database đơn hàng của mình

		//		return Ok(response);
		//	}
		//	catch (Exception ex)
		//	{
		//		var error = new { ex.GetBaseException().Message };
		//		return BadRequest(error);
		//	}
		//}
	}
}
