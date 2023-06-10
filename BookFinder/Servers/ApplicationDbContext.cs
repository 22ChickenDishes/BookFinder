using BookFinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BookFinder.Servers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.OnConfiguring(new DbContextOptionsBuilder());
          // options.UseSqlServer("Server=localhost;Database=DB_LibraryManagement;Trusted_Connection=True");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=DB_LibraryManagement;Trusted_Connection=True");
        }

     
        public virtual DbSet<Book> Books2 { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BorrowingSheet> BorrowingSheets { get;set;}

        public virtual DbSet<OrderSheet> OrderSheets { get; set; }
    }
}
