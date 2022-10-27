using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class BookStoreDbContext:DbContext 
    {
        public BookStoreDbContext()
            : base("Data Source=.;Initial Catalog=BookStore3;Integrated Security=true")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
    }
}