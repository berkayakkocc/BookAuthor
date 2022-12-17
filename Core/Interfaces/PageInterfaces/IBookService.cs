using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Book;
using Core.Interfaces.GenericInterfaces.CrudInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.PageInterfaces
{
    public interface IBookService:IBasicCreateEntity<CreateBookDto,NoContent>,
        IBasicDeleteEntity<DeleteBookDto,NoContent>,
        IBasicUpdateEntity<UpdateBookDto,NoContent>,
        IBasicGetByIdEntity<int,BookDto>,
        IBasicGetAllEntity<NoContent,List<BookDto>>
    {
    }
}
