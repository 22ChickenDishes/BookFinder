using BookFinder.Models;
using BookFinder.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Helper.DBHelper
{
    public class BookDbManage:IRepository<Book>
    {
        private readonly ApplicationDbContext dbContext;

        public BookDbManage(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public  Book Create(Book book)
        {
            var s = dbContext.Books2.Find(book.ID);
            if (s == null)
            {
                var ENT = dbContext.Books2.Add(book);
                var status = dbContext.SaveChanges();
            }
            return book;
           
        }

        public Book Delete(string ID)
        {
            var s = dbContext.Books2.Find(ID);
            if (s != null)
            {
                dbContext.Books2.Remove(s);
                dbContext.SaveChanges();
            }
            return s;
        }

        public Book Delete(int id)
        {
            var s = dbContext.Books2.Find(id);
            if (s != null)
            {
                dbContext.Books2.Remove(s);
                dbContext.SaveChanges();
            }
            return s;
        }

        public IEnumerable<Book> GetAll()
        {
            return dbContext.Books2;
        }

        public Book GetValue(string ID)
        {
            return dbContext.Books2.Find(ID);
        }

        public Book GetValue(int id)
        {
            return dbContext.Books2.Find(id);
        }

        public Book Update(Book book)
        {
            var s = dbContext.Books2.Attach(book);
            s.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return book;
        }
    }
}
