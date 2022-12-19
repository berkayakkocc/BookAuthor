using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Author;
using Core.Models.PageEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.PageInterfaces.RepositoryInterfaces
{
    public interface IAuthorServiceRepository
    {
        Task<GenericResponseDto<NoContent>> CreateAuthorWithCrossTable(Author author, CreateAuthorWithCrossDto createAuthorWithCross);
        //Task<GenericResponseDto<NoContent>> CreateAuthorWithCrossTable(DeleteAuthorWithCrossDto deleteAuthorWithCross);
    }
}
