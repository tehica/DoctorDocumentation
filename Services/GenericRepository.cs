using DoctorDoc1.Data;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public GenericRepository()
        {

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }


        public async Task CreateAsync(T model)
        {
            _db.Set<T>().Add(model);
            await _db.SaveChangesAsync();
        }


        public async Task UpdateAsync(T model)
        {
            _db.Set<T>().Update(model);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T model)
        {
            _db.Set<T>().Remove(model);
            await _db.SaveChangesAsync();
        }

    }
}
