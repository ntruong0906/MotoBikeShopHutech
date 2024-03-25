using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoBikeShop.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public async Task<IEnumerable<T>> GetAll()
        {
            // Thực hiện lấy tất cả các đối tượng T từ nguồn dữ liệu
            await Task.Delay(1000); // Giả định là lấy dữ liệu mất 1 giây
            var data = new List<T>(); // Dữ liệu sau khi lấy được từ nguồn dữ liệu
            return data;
        }

        public async Task<T> GetByIdTypeInt(int id)
        {
            // Thực hiện lấy đối tượng T dựa trên id kiểu int từ nguồn dữ liệu
            await Task.Delay(500); // Giả định là lấy dữ liệu mất 0.5 giây
            var data = default(T); // Đối tượng T sau khi lấy được từ nguồn dữ liệu
            return data;
        }

        public async Task<T> GetByIdTypeString(int id)
        {
            // Thực hiện lấy đối tượng T dựa trên id kiểu string từ nguồn dữ liệu
            await Task.Delay(500); // Giả định là lấy dữ liệu mất 0.5 giây
            var data = default(T); // Đối tượng T sau khi lấy được từ nguồn dữ liệu
            return data;
        }

        public async Task<T> Create(T entity)
        {
            // Thực hiện tạo mới đối tượng T trong nguồn dữ liệu
            await Task.Delay(500); // Giả định là tạo mới mất 0.5 giây
            var newEntity = entity; // Đối tượng T sau khi được tạo mới trong nguồn dữ liệu
            return newEntity;
        }

        public async Task<bool> DeleteTypeInt(int id)
        {
            // Thực hiện xóa đối tượng T dựa trên id kiểu int trong nguồn dữ liệu
            await Task.Delay(500); // Giả định là xóa mất 0.5 giây
            var isDeleted = true; // Kết quả xóa đối tượng T
            return isDeleted;
        }

        public async Task<bool> DeleteTypeString(int id)
        {
            // Thực hiện xóa đối tượng T dựa trên id kiểu string trong nguồn dữ liệu
            await Task.Delay(500); // Giả định là xóa mất 0.5 giây
            var isDeleted = true; // Kết quả xóa đối tượng T
            return isDeleted;
        }

        public async Task<T> Update(int id, T entity)
        {
            // Thực hiện cập nhật đối tượng T dựa trên id trong nguồn dữ liệu
            await Task.Delay(500); // Giả định là cập nhật mất 0.5 giây
            var updatedEntity = entity; // Đối tượng T sau khi được cập nhật trong nguồn dữ liệu
            return updatedEntity;
        }

        public async Task<T> Update(string id, T entity)
        {
            // Thực hiện cập nhật đối tượng T dựa trên id kiểu string trong nguồn dữ liệu
            await Task.Delay(500); // Giả định là cập nhật mất 0.5 giây
            var updatedEntity = entity; // Đối tượng T sau khi được cập nhật trong nguồn dữ liệu
            return updatedEntity;
        }

        public Task<T1> Create<T1>(T1 entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateTypeInt(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateTypeString(string id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}