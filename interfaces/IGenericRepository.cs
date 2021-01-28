using DoctorDoc1.Models;
using DoctorDoc1.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id); // :)

        Task<IEnumerable<T>> ListAllAsync(); // *

        // SPEC
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

        Task UpdateAsync(T model);

        Task CreateAsync(T model);

        Task DeleteAsync(T model);
    }
}
