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
    public class AdminService :IAdminService
    {
        IBookRepository BRepo = new BookRepository();
        IUserRepository URepo = new UserRepository();
        public string GetAllBooks()
        {
            string str = "";
            foreach (Book b in BRepo.ReadAll())
            {
                if (b.Status == StatusEnum.available)
                { str += $"{b.Id}) {b.Title}   -{b.Description}-     |{b.Author}    {b.Price}$   |>  {b.Status}"; }
                else { str += $"{b.Id}) {b.Title}   -{b.Description}-     |{b.Author}    {b.Price}$   |> {b.Status}  >  {URepo.ReadById(b.Id).UserName}"; }
            }
            if (str == "") { return "no books in database"; }
            return str;
        }
        public List<User> GetUsers()
        {
            return URepo.ReadAll();
        }
        public User GetUserById(int id)
        {
            return URepo.ReadById(id);
        }

    }
}
