using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public class AuthorRepository : CRUDRepository<Author>
    {
        public AuthorRepository() : base(@"D:\tmp\database.db", "authors") { }
    }
}
