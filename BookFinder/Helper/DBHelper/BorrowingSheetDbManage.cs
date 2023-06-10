using BookFinder.Models;
using BookFinder.Servers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Helper.DBHelper
{
    public class BorrowingSheetDbManage : IRepository<BorrowingSheet>
    {
        private readonly ApplicationDbContext dbContext;

        public BorrowingSheetDbManage(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public BorrowingSheet Create(BorrowingSheet borrowingSheet)
        {
            if (dbContext.BorrowingSheets.Find(borrowingSheet) != null)
            {
                var ENT = dbContext.BorrowingSheets.Add(borrowingSheet);

                var status = dbContext.SaveChanges();
            }

            return borrowingSheet;
        }

        public BorrowingSheet Delete(int id)
        {
            var s = dbContext.BorrowingSheets.Find(id);
            if (s != null)
            {
                dbContext.BorrowingSheets.Remove(s);
                dbContext.SaveChanges();
            }
            return s;
        }

        public IEnumerable<BorrowingSheet> GetAll()
        {
            return dbContext.BorrowingSheets;
        }

        public BorrowingSheet GetValue(int id)
        {
            return dbContext.BorrowingSheets.Find(id);
        }

        public BorrowingSheet Update(BorrowingSheet t)
        {
            var s = dbContext.BorrowingSheets.Attach(t);
            s.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return t;
        }
    }
}
