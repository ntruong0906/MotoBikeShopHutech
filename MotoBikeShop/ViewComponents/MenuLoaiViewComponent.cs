using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly motoBikeShopDbContext db;

        public MenuLoaiViewComponent(motoBikeShopDbContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(loai => new MenuLoaiVM
            {
            MaLoai  =   loai.MaLoai,
            TenLoai =    loai.TenLoai,
            SoLuong =   loai.HangHoas.Count
            }).OrderBy(p => p.TenLoai);
            return View(data); //Default.cshtml
        }



    }
}
