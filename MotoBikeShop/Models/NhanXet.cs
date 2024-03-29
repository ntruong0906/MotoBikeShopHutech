using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.Models
{
    public class NhanXet
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string MaGy { get; set; } = null!;
            public string NoiDung { get; set; } = null!;
          
            public DateOnly NgayGy { get; set; }

            public string? HoTen { get; set; }

            public string? DienThoai { get; set; }
            [ForeignKey("UserId")]
            public virtual ApplicationUser User { get; set; }
    }
}
