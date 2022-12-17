using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Author;
using Core.Interfaces.GenericInterfaces.CrudInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.PageInterfaces
{
    public interface IAuthorService : IBasicCreateEntity<CreateAuthorDto, NoContent>,
       IBasicDeleteEntity<DeleteAuthorDto, NoContent>,
       IBasicUpdateEntity<UpdateAuthorDto, NoContent>,
       IBasicGetByIdEntity<int, AuthorDto>,
       IBasicGetAllEntity<NoContent, List<AuthorDto>>
    {
    }
}
