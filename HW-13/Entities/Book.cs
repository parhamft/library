using HW_13.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Entities
{
    public class Book
    {
        public int Id{ get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
        public string Author{ get; set; }
        public decimal Price {  get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.available;
        public int? UserId { get; set; }
        public User User { get; set; }

        public Book()
        {
            
        }
    }
}
