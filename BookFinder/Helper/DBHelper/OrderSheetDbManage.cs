using BookFinder.Models;
using BookFinder.Servers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Helper.DBHelper
{
    public class OrderSheetDbManage : IRepository<OrderSheet>
    {

        private readonly ApplicationDbContext dbContext;

        public OrderSheetDbManage(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public OrderSheet Create(OrderSheet orderSheet)
        {
            if (dbContext.OrderSheets.Find(orderSheet.BookID )!=null)
            {
                var ENT = dbContext.OrderSheets.Add(orderSheet);

                var status = dbContext.SaveChanges();
            }
            
            return orderSheet;
        }

        //public OrderSheet Create(OrderSheet t)
        //{
        //    throw new NotImplementedException();
        //}

        public OrderSheet Delete(int id)
        {
            var s = dbContext.OrderSheets.Find(id);
            if (s != null)
            {
                dbContext.OrderSheets.Remove(s);
                dbContext.SaveChanges();
            }
            return s;
        }

        public IEnumerable<OrderSheet> GetAll()
        {
            return dbContext.OrderSheets;
        }
   
  
        public OrderSheet GetValue(int id)
        {
           return dbContext.OrderSheets.Find(id);
        }

        public OrderSheet Update(OrderSheet t)
        {
            var s = dbContext.OrderSheets.Attach(t);
            s.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return t;
        }
    }
}
