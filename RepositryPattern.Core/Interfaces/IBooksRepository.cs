using RepositryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Interfaces
{
    public interface IBooksRepository : IBaseRepositry<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
