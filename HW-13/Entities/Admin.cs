using System.ComponentModel.DataAnnotations;

namespace HW_13.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }

        public Admin(string username,string password)
        {
            this.UserName = username;
            this.Password = password;
        }
        public Admin()
        {
            
        }
        public bool CheckPassword(string password)
        {
            if (this.Password == password) { return true; }
            return false;
        }
    }
}
