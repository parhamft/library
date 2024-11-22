using HW_13.Contracts;
using HW_13.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        LibDBContext _dbContext = new LibDBContext();
        public bool Create(Admin admin)
        {
            try { _dbContext.Admins.Add(admin); }
            catch (Exception ex) { return false; }
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _dbContext.Admins.Remove(ReadById(id));
            if (ReadById(id) != null) { return false; }
            _dbContext.SaveChanges();
            return true;
        }

        public List<Admin> ReadAll()
        {
            return _dbContext.Admins.AsNoTracking().ToList();
        }

        public Admin ReadById(int id)
        {
            
            return _dbContext.Admins.AsNoTracking().FirstOrDefault();
        }

        public bool Update(Admin admin)
        {
            try
            { _dbContext.Admins.Update(admin); }
            catch (Exception ex) { return false; }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
