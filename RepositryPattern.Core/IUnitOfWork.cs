using RepositryPattern.Core.Interfaces;
using RepositryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core
{
    public interface IUnitOfWork: IDisposable
    {
        //add refernce for each repository
        IBaseRepositry<Author> Authors { get; }
        //IBaseRepositry<Book> Books { get; }

        IBooksRepository Books { get; }

    int Complete();
    }
}
