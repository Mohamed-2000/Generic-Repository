using RepositryPattern.Core.Interfaces;
using RepositryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.EF.Repositries
{
    
    public class BooksRepository : BaseRepositry<Book>, IBooksRepository
    {
        private readonly RepoDbContext _Context;
        public BooksRepository(RepoDbContext Context): base(Context )
        {
            
        }
        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
