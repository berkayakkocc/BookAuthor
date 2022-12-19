using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageDtos.Book
{
    public class CreateBookFromAuthorDto
    {
        public CreateBookFromAuthorDto()
        {

        }
        public CreateBookFromAuthorDto(string name, int pageNumber, int yearOfWrite, string type)
        {
            Name = name;
            PageNumber = pageNumber;
            YearOfWrite = yearOfWrite;
            Type = type;
        }

        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int YearOfWrite { get; set; }
        public string Type { get; set; }
        
    }
}
