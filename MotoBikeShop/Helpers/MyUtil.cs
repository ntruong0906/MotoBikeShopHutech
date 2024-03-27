using System;
using System.Text;

namespace MotoBikeShop.Helpers
{
    public class MyUtil
    {
        public static string UpLoadHinh(IFormFile Hinh, string folder)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);

                using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
                {
                    Hinh.CopyTo(myfile);
                }
                return Hinh.FileName;
            }
            catch
            {
                return string.Empty;
            }

        }
        public static string SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName); //Thay đổi đường dẫn theo cấu hình của bạn

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                 image.CopyTo(fileStream);
            }
            return "/images/" + image.FileName; // Trả về đường dẫn tương đối
        }
        public static string GenerateRamdomKey(int lenght = 5)
        {
            var pattern = @"qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM~!@#$%^&*()_-+={}[];;:'<>/?\";
            var sb = new StringBuilder();
            var rd = new Random();
            for (int i = 0; i < lenght; i++)
            {
                sb.Append(pattern[rd.Next(0, pattern.Length)]);
            }
            return sb.ToString();
        }
    }
}
