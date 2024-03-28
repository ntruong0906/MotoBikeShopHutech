    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MotoBikeShop.Data;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;

    namespace MotoBikeShop.Controllers
    {
        public class HangHoaController : Controller
        {
            //private readonly ICartService _cartService;
            private readonly motoBikeVHDbContext db;

            
        public HangHoaController(motoBikeVHDbContext context)
            {
                db = context;
        }
            public IActionResult Index(int? loai)
            {
                var hanghoas = db.HangHoas.AsQueryable();
                if (loai.HasValue)
                {
                    hanghoas = hanghoas.Where(p => p.MaLoai == loai.Value);

                }
                var result = hanghoas.Select(p => new HangHoaVM
                {
                    MaHh = p.MaHH,
                    TenHh = p.TenHH,
                    DonGia = p.DonGia ?? 0,
                    Hinh = p.Hinh ?? "",
                    MoTaNgan = p.MoTaDonVi ?? "",
                    TenLoai = p.MaLoaiNavigation.TenLoai
                });
                return View(result);
            }
            public IActionResult Search(String? query)
            {
                var hanghoas = db.HangHoas.AsQueryable();
                if (query != null)
                {
                    hanghoas = hanghoas.Where(p => p.TenHH.Contains(query));

                }
                var result = hanghoas.Select(p => new HangHoaVM
                {
                    MaHh = p.MaHH,
                    TenHh = p.TenHH,
                    DonGia = p.DonGia ?? 0,
                    Hinh = p.Hinh ?? "",
                    MoTaNgan = p.MoTaDonVi ?? "",
                    TenLoai = p.MaLoaiNavigation.TenLoai
                });
                return View(result);
            }
        public IActionResult Detail(int id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .SingleOrDefault(p => p.MaHH == id);
            if (data == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }

            var result = new CTHangHoaVM
            {
                MaHh = data.MaHH,
                TenHh = data.TenHH,
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                MoTaNgan = data.MoTaDonVi ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,//tính sau
                DiemDanhGia = 5,//check sau
            };
            return View(result);
        }
        

    }

    }
