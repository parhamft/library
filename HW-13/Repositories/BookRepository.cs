using HW_13.Contracts;
using HW_13.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.Repositories
{
    public class BookRepository : IBookRepository
    {
        LibDBContext _dbContext=new LibDBContext();
        public bool Create(Book book)
        {
            try { _dbContext.books.Add(book); }
            catch (Exception ex) { return false; }
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            _dbContext.books.Remove(ReadById(id));
            if (ReadById(id) != null) { return false; }
            _dbContext.SaveChanges();
            return true;
        }

        public List<Book> ReadAll()
        {
            return _dbContext.books.AsNoTracking().ToList();
        }

        public Book ReadById(int id)
        {
            return _dbContext.books.AsNoTracking().FirstOrDefault(x=>x.Id==id);
        }

        public bool Update(Book book)
        {
            try
            { _dbContext.books.Update(book); }
            catch (Exception ex) { return false; }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
