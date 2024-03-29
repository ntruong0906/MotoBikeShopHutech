
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Momo;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;
using Newtonsoft.Json.Linq;
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


		public IActionResult Payment(CartItem model)
		{

           
			//request params need to request to MoMo system
			string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
			string partnerCode = "MOMOOJOI20210710";
			string accessKey = "iPXneGmrJH0G8FOP";
			string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
			string orderInfo = "MotoBike Shop";
			string returnUrl = "https://localhost:44375/Cart/ConfirmPaymentClient";
			string notifyurl = "https://localhost:44375/Cart/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            //String amount = model.ThanhTien.ToString();
			string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
			string requestId = DateTime.Now.Ticks.ToString();
			string extraData = "";

			//Before sign HMAC SHA256 signature
			string rawHash = "partnerCode=" +
				partnerCode + "&accessKey=" +
				accessKey + "&requestId=" +
				requestId + "&amount=" +
				amount + "&orderId=" +
				orderid + "&orderInfo=" +
				orderInfo + "&returnUrl=" +
				returnUrl + "&notifyUrl=" +
				notifyurl + "&extraData=" +
				extraData;

			MoMoSecurity crypto = new MoMoSecurity();
			//sign signature SHA256
			string signature = crypto.signSHA256(rawHash, serectkey);

			//build body json request
			JObject message = new JObject
			{
				{ "partnerCode", partnerCode },
				{ "accessKey", accessKey },
				{ "requestId", requestId },
				{ "amount", amount },
				{ "orderId", orderid },
				{ "orderInfo", orderInfo },
				{ "returnUrl", returnUrl },
				{ "notifyUrl", notifyurl },
				{ "extraData", extraData },
				{ "requestType", "captureMoMoWallet" },
				{ "signature", signature }

			};

			string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

			JObject jmessage = JObject.Parse(responseFromMomo);

			if (jmessage.TryGetValue("payUrl", out JToken payUrlToken))
			{
				return Redirect(payUrlToken.ToString());
			}
			else
			{
				// Handle error when "payUrl" does not exist in the response
				// For example, you may want to redirect to an error page or back to the checkout form
				return View("Error");
			}
		}

		//Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
		//errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
		//Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
		public IActionResult ConfirmPaymentClient(Result result)
		{
			//lấy kết quả Momo trả về và hiển thị thông báo cho người dùng (có thể lấy dữ liệu ở đây cập nhật xuống db)
			string rMessage = result.message;
			string rOrderId = result.orderId;
			string rErrorCode = result.errorCode; // = 0: thanh toán thành công
			return View();
		}

		[HttpPost]
		public void SavePayment()
		{
			//cập nhật dữ liệu vào db
		
		}
	}
}
