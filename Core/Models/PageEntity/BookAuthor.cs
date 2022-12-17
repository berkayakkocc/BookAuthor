using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.PageEntity
{
    public class BookAuthor:BaseEntity
    {
        public BookAuthor()
        {

        }
        public BookAuthor(long? bookId, long? authorId, Book book, Author author)
        {
            BookId = bookId;
            AuthorId = authorId;
            Book = book;
            Author = author;
        }

        public long? BookId { get; set; }
        public long? AuthorId { get; set; }
        
        public Book Book { get; set; }
       
        public Author Author { get; set; }
    }
}
