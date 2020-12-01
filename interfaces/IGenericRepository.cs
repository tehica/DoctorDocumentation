using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);

        Task UpdateAsync(T model);

        Task CreateAsync(T model);

        Task DeleteAsync(T model);
    }
}
