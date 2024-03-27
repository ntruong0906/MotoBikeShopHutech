using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Controllers
{
    public class HangHoaController : Controller
    {
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
            var data = db.HangHoas.Include(p => p.MaLoai)
                .SingleOrDefault(p => p.MaHH == id);
            if (data == null)
            {
                TempData["Message"] = $"Khong Tim Thay San Pham Co Ma {id}";
                return Redirect("/404");
            }
            var result = new CTHangHoaVM
            {
                MaHh = data.MaHH,
                TenHh = data.TenHH,
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? String.Empty,
                Hinh = data.Hinh ?? String.Empty,
                MoTaNgan = data.MoTaDonVi ?? String.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,
                DiemDanhGia = 5,

            };
            return View(result);
        }
    }

}
