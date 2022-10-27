using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class AuthorDomain
    {
        public AuthorRepository authorRepository = new AuthorRepository();

        public List< Author> GetAllAuthors()
        {
            return authorRepository.GetAllAuthors();
        }
        public Author Insert(Author author)
        {
            return authorRepository.Insert(author);
        }

        public Author Edit(int id)
        {
            return authorRepository.Edit(id);
        }

        public Author Modify(Author author)
        {
            return authorRepository.Modify(author);
        }

        public Author Delete(int id)
        {
            return authorRepository.Delete(id);
        }

        public Author ConfirmDelete(int id)
        {
            return authorRepository.ConfirmDelete(id);
        }
    }
}
