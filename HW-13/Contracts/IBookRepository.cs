using HW_13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Contracts
{
    public interface IBookRepository
    {
        public bool Create(Book book);
        public List<Book> ReadAll();
        public Book ReadById(int id);
        public bool Update(Book book);
        public bool Delete(int id);
    }
}
