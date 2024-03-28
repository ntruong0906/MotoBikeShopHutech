using MotoBikeShop.Data;
using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.Models
{
    public class TrangThai
    {
        [Key]
        public int MaTrangThai { get; set; }

        public string TenTrangThai { get; set; } = null!;

        public string? MoTa { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
