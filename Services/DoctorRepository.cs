using DoctorDoc1.Data;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Services
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ApplicationDbContext _db;

        public DoctorRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}
