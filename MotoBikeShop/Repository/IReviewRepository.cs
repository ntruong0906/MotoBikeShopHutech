using MotoBikeShop.Data;
using MotoBikeShop.Models;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Repository
{
    public interface IReviewRepository
    {
		Task<IEnumerable<NhanXet>> GetAllAsync();
		Task AddAsync(NhanXet nhanXet);
	}
}
