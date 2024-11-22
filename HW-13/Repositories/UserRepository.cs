using HW_13.Contracts;
using HW_13.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW_13.Repositories
{
    public class UserRepository : IUserRepository
    {
        LibDBContext _dbContext= new LibDBContext();
        public bool Delete(int id)
        {
            _dbContext.Users.Remove(ReadById(id));
            if (ReadById(id)!=null) { return false; }
            _dbContext.SaveChanges();
            return true;
        }

        public List<User> ReadAll()
        {
            return _dbContext.Users.AsNoTracking().ToList();
        }
        

        public User ReadById(int id)
        {
            return _dbContext.Users.AsNoTracking().FirstOrDefault();
        }

        public bool Update(User user)
        {
            try
            { _dbContext.Users.Update(user); }
            catch (Exception ex) { return false; }
            _dbContext.SaveChanges();
            return true;
        }

        public bool Create(User u)
        {
            try { _dbContext.Users.Add(u); }
            catch (Exception ex) { return false; }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
