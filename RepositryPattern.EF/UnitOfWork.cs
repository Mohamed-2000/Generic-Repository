using RepositryPattern.Core;
using RepositryPattern.Core.Interfaces;
using RepositryPattern.Core.Models;
using RepositryPattern.EF.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.EF
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly RepoDbContext _context;

        // add property for each interface we have in our application
        public IBaseRepositry<Author> Authors { get; private set; }
        //public IBaseRepositry<Book> Books { get; private set; }
        public IBooksRepository Books { get; private set; }
        public UnitOfWork(RepoDbContext context)
        {
            _context = context;
            Authors = new BaseRepositry<Author>(_context);
            Books = new BooksRepository(_context);
        }

        public int Complete()
        {
            // gives you number of rows affected by transaction in Database
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
