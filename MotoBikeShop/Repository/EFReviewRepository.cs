using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotoBikeShop.Data;
using MotoBikeShop.Models;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Repository
{
    public class EFReviewRepository : IReviewRepository
    {
        private readonly motoBikeVHDbContext _db;

        public EFReviewRepository(motoBikeVHDbContext context)
        {
            _db = context;
        }

		public async Task<IEnumerable<NhanXet>> GetAllAsync()
		{
			return await _db.NhanXets.Include(p => p.MaGy).ToListAsync();
		}
		public async Task AddAsync(NhanXet nhanXet)
		{
			_db.NhanXets.AddAsync(nhanXet);
			await _db.SaveChangesAsync();
		}
	}
}
