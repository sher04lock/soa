using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var books = new List<Book>
            {
                new Book() {BookTitle = "Fifty shades of C#", ISBN = "fsocsharp12345"},
                new Book() {BookTitle = "Rodzynki", ISBN = "120fs123xzs2JAlwekA"},
                new Book() {BookTitle = "Zurawina", ISBN = "zurzurzu123"}
            };
            books.ForEach(i => context.Books.Add(i));
            context.SaveChanges();

            var authors = new List<Author>()
            {
                new Author() {AuthorName = "Jan", AuthorSurname = "Zbedny"},
                new Author() {AuthorName = "Czeslaw", AuthorSurname = "Nowak"},
                new Author() {AuthorName = "Jan", AuthorSurname = "Niezbedny"}
            };
            authors.ForEach(g => context.Authors.Add(g));
            context.SaveChanges();
        }
    }
}
