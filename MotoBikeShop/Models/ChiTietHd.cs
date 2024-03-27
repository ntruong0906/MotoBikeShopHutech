using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
    public class ChiTietHd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCT { get; set; }

        public int MaHD { get; set; }

        public int MaHH { get; set; }

        public double DonGia { get; set; }

        public int SoLuong { get; set; }

        public double GiamGia { get; set; }

        [ForeignKey("MaHH")]
        public virtual HangHoa HangHoa { get; set; }

        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }
    }
}