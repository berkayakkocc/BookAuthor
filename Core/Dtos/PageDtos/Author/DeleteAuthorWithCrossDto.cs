using Core.Dtos.PageDtos.Book;
using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageDtos.Author
{
    public class DeleteAuthorWithCrossDto:BaseIdEntity
    {
        public DeleteAuthorWithCrossDto(DeleteAuthorDto deleteAuthor, DeleteBookDto deleteBook)
        {
            DeleteAuthor = deleteAuthor;
            DeleteBook = deleteBook;
        }

        public DeleteAuthorDto DeleteAuthor { get; set; }
        public DeleteBookDto DeleteBook { get; set; }
    }
}
