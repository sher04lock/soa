using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Models;

namespace Repositories
{
    public class BookRepository : CRUDRepository<Book>
    {
        public BookRepository() : base(@"D:\tmp\database.db", "books") { }
    }
}
