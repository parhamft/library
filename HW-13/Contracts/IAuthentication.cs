using HW_13.Entities;
using HW_13.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Contracts
{
    public interface IAuthentication
    {
        public object? Login(string username, string password);

        public string Register(string username, string password, RoleEnum role);
    }
}
