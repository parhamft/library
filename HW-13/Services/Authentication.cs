using HW_13.Contracts;
using HW_13.Entities;
using HW_13.Enums;
using HW_13.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Services
{
    public class Authentication : IAuthentication
    {
        IUserRepository Urepo = new UserRepository();
        IAdminRepository Arepo = new AdminRepository();
        public object? Login(string username, string password)
        {
            User user = Urepo.ReadAll().FirstOrDefault(user => user.UserName == username);
            Admin admin = Arepo.ReadAll().FirstOrDefault(admin => admin.UserName == username);


            if (user != null) { if (user.CheckPassword(password) == true) { return user; }; }
            if (admin != null) { if (admin.CheckPassword(password) == true) { return admin; } }
            return null;
        }

        public string Register(string username, string password,RoleEnum role)
        {
            if (Urepo.ReadAll().Any(user => user.UserName == username) == true) { return "username is already taken"; }
            if (Arepo.ReadAll().Any(admin => admin.UserName == username) == true) { return "username is already taken"; }

            if (role == RoleEnum.User)
            { Urepo.Create(new User(username, password,DateOnly.FromDateTime(DateTime.Now).AddDays(30))); }
            else if (role == RoleEnum.Admin) { Arepo.Create(new Admin(username, password)); }
            
            return "User registered";
        }
    }
}
