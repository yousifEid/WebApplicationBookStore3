using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        public List<Author> GetAllAuthors()
        {
            var authors = db.Authors.ToList();

            return authors;
        }

        public Author Insert(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author;
        }

        public Author Edit(int id)
        {
            var author = db.Authors.Find(id);
            return author;
        }

        public Author Modify(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
            return author;
        }

        public Author Delete(int id)
        {
            var author = db.Authors.Find(id);
            return author;
        }

        public Author ConfirmDelete(int id)
        {
            var author = db.Authors.Find(id);
            db.Entry(author).State = EntityState.Deleted;
            db.Authors.Remove(author);
            db.SaveChanges();
            return author;
        }
    }
}
