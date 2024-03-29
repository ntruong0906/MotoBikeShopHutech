using MotoBikeShop.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoBikeShop.ViewModels
{
	public class NhanXetVM
	{
		public string NoiDung { get; set; } = null!;

		public DateOnly NgayGy { get; set; }

		public string? HoTen { get; set; }

		
	}
}
