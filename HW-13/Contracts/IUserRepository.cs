using HW_13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Contracts
{
    public interface IUserRepository
    {
        public bool Create(User user);
        public List<User> ReadAll();
        public User ReadById(int id);
        public bool Update(User user);
        public bool Delete(int id);
    }
}
