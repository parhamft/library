using HW_13.Contracts;
using HW_13.Entities;
using HW_13.Enums;
using HW_13.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Services
{
    public class UserService : IUserService
    {
        IBookRepository BRepo = new BookRepository();
        IUserRepository UserRepo = new UserRepository();
        public List<Book> ShowAll()
        {
            return BRepo.ReadAll().Where(x=>x.Status==StatusEnum.available).ToList();
        }
        public string BorrowBook(int id,int userId)
        {
            Book b = BRepo.ReadById(id);
            if (b==null || b.Status==StatusEnum.unavailable) { return "that book does not exist"; }
            b.UserId = userId;
            b.Status=StatusEnum.unavailable;
            BRepo.Update(b);
            return "book borrowed";
        }
        public string returnbook(int id, int userid)
        {
            Book b = BRepo.ReadById(id);
            if (b == null || b.UserId != userid) { return "You have not borrowed that book"; }
            b.UserId = null;
            b.Status = StatusEnum.available;

            BRepo.Update(b);
            return "book returned";
        }
        public List<Book> ShowBorrowedBooks(int UserId)
        {
            return BRepo.ReadAll().Where(x => x.UserId == UserId).ToList();
        }
        public string UpdateUser(User user)
        {

            if (UserRepo.Update(user)==true)
            {return "User Updated"; }
            return "something went wrong";
        }

    }
}
