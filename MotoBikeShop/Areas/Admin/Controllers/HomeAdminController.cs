using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Areas.Admin.Models;
using MotoBikeShop.Data;

namespace MotoBikeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly motoBikeShopDbContext db;

        public HomeAdminController(motoBikeShopDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DangNhap(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            var model = new LoginModel();
            return View(model);
           
        }

        [HttpPost]
        public IActionResult DangNhap(LoginModel model, string returnUrl)
        {
            try
            {
                // Kiểm tra thông tin đăng nhập trong cơ sở dữ liệu
                ViewBag.returnUrl = returnUrl;
                var admin = db.NhanViens.SingleOrDefault(kh => kh.MaNv == model.UserName);
                if (admin == null)
                {
                    ModelState.AddModelError("loi", "Không có nhân viên này!");
                    return View(model);
                }
                if (admin.MatKhau != model.Password)
                {
                    ModelState.AddModelError("loi", "Sai mật khẩu!");
                    return View(model);
                }

              
            }
            catch (Exception ex)
            {

            }
            // Chuyển hướng đến returnUrl
            if (!string.IsNullOrEmpty(returnUrl))
                return Redirect(returnUrl);
            // Chuyển hướng đến action Index của HangHoaController trong vùng admin
            return RedirectToAction("Index", "HangHoas", new { Areas = "Admin" });
        }

    }
}