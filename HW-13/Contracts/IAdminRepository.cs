using HW_13.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Contracts
{
    public interface IAdminRepository
    {
        public bool Create(Admin admin);

        public bool Delete(int id);

        public List<Admin> ReadAll();

        public Admin ReadById(int id);

        public bool Update(Admin admin);
    }
}
