using HW_13.Entities;
using HW_13.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Contracts
{
    public interface IUserService
    {
        public List<Book> ShowAll();
        public string BorrowBook(int id, int userId);
        public string returnbook(int id, int userid);
        public List<Book> ShowBorrowedBooks(int UserId);
        public string UpdateUser(User user);
    }
}
