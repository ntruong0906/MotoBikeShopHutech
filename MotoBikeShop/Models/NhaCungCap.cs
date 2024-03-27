using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.Data
{
    public class NhaCungCap
    {
        [Key]
        public string MaNCC { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenCongTy { get; set; }

        [Required]
        [MaxLength(50)]
        public string Logo { get; set; }

        [MaxLength(50)]
        public string NguoiLienLac { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string DienThoai { get; set; }

        [MaxLength(50)]
        public string DiaChi { get; set; }

        public string MoTa { get; set; }
    }
}