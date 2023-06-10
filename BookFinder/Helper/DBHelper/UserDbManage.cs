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
    public class UserDbManage : IRepository<User>
    {
        private readonly ApplicationDbContext dbContext;

        public UserDbManage(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public User Create(User t)
        {
            if (dbContext.Users.Find(t) != null)
            {
                var ENT = dbContext.Users.Add(t);

                var status = dbContext.SaveChanges();
            }

            return t;
        }

        public User Delete(int id)
        {
            var s = dbContext.Users.Find(id);
            if (s != null)
            {
                dbContext.Users.Remove(s);
                dbContext.SaveChanges();
            }
            return s;
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }

        public User GetValue(int id)
        {
            return dbContext.Users.Find(id);
        }

        public User Update(User t)
        {
            var s = dbContext.Users.Attach(t);
            s.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return t;
        }
    }
}
