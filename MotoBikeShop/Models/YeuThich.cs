using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.Data
{
    public class YeuThich
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaYT { get; set; }

        public int? MaHH { get; set; }

        [Required]
        [MaxLength(100)]
        public string MaKH { get; set; }

        public DateTime? NgayChon { get; set; }

        [MaxLength(255)]
        public string MoTa { get; set; }


        [ForeignKey("MaHH")]
        public virtual HangHoa HangHoa { get; set; }
    }
}