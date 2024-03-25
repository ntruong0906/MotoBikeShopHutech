using MotoBikeShop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoBikeShop.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<Loai>> GetAllLoai(); // Thêm phương thức này
        Task<IEnumerable<T>> GetAllNhaCungCap();
        Task<T> GetByIdTypeInt(int id);
        Task<T> GetByIdTypeString(int id);
#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        Task<T> Create<T>(T entity);
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        Task<bool> DeleteTypeInt(int id);
        Task<bool> DeleteTypeString(int id);
        Task<T> UpdateTypeInt(int id, T entity);
        Task<T> UpdateTypeString(string id, T entity);
        bool ExistsTypeInt(int maHh);
    }
}