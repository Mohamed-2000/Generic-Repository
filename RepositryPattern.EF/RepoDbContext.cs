using Microsoft.EntityFrameworkCore;
using RepositryPattern.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.EF
{
    public class RepoDbContext:DbContext
    {
        public RepoDbContext(DbContextOptions<RepoDbContext> options):base(options)
        {

        }

        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Book> Books { get; set; }
        
    }
}
