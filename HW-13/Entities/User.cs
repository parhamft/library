using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Entities
{
    public class User
    {
        public int Id{ get; set; }
        public string UserName{ get; set; }
        [MaxLength(20)]
        public string Password{ get; set; }
        public DateOnly ActiveUntil { get; set; }
        public List<Book> Books{ get; set; }

        public User(string username, string password, DateOnly activeUntil)
        {
            this.UserName = username;
            this.Password = password;
            this.ActiveUntil = activeUntil;
        }
        public User()
        {
            
        }
        public bool CheckPassword(string password)
        {
            if (this.Password == password) { return true; }
            return false;
        }
    }
}
