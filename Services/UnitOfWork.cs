using DoctorDoc1.Data;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        private Hashtable _repositories;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }

        // zasto ova metoda?
        public void Dispose()
        {
            _db.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if(_repositories == null)
            {
                _repositories = new Hashtable();
            }

            // get type of TEntity
            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(
                                         repositoryType.MakeGenericType(typeof(T)), _db);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}
