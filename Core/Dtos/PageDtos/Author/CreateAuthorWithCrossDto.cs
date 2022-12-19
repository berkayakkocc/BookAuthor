using Core.Dtos.PageDtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageDtos.Author
{
    public class CreateAuthorWithCrossDto
    {
        public CreateAuthorWithCrossDto(CreateAuthorDto createAuthor, CreateBookFromAuthorDto createBookFromAuthor)
        {
            CreateAuthor = createAuthor;
            CreateBookFromAuthor = createBookFromAuthor;
        }

        public CreateAuthorDto CreateAuthor { get; set; }
        public CreateBookFromAuthorDto CreateBookFromAuthor { get; set; }
    }
}
