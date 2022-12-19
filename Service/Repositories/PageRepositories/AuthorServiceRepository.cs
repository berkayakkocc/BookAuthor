using AutoMapper;
using Core.Dtos.Constants;
using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Author;
using Core.Interfaces.GenericInterfaces;
using Core.Interfaces.PageInterfaces.RepositoryInterfaces;
using Core.Models.PageEntity;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.PageRepositories
{
    public class AuthorServiceRepository : IAuthorServiceRepository
    {
        private readonly IMapper _mapper;
        private IGenericCrudRepository<Author> _genericAuthorCrudRepository;
        private IGenericCrudRepository<BookAuthor> _genericBookAuthorCrudRepository;

        public AuthorServiceRepository(IMapper mapper, IGenericCrudRepository<Author> genericAuthorCrudRepository, IGenericCrudRepository<BookAuthor> genericBookAuthorCrudRepository)
        {
            _mapper = mapper;
            _genericAuthorCrudRepository = genericAuthorCrudRepository;
            _genericBookAuthorCrudRepository = genericBookAuthorCrudRepository;
        }

        public async Task<GenericResponseDto<NoContent>> CreateAuthorWithCrossTable(Author author, CreateAuthorWithCrossDto createAuthorWithCross)
        {
            try
            {
                if (createAuthorWithCross.CreateBookFromAuthor != null)
                {
                    BookAuthor bookAuthor = _mapper.Map<BookAuthor>(createAuthorWithCross.CreateBookFromAuthor);
                    bookAuthor.AuthorId = author.Id;

                    await _genericBookAuthorCrudRepository.InsertWithoutTransaction(bookAuthor);
                }
            }
            catch (Exception)
            {
                await _genericAuthorCrudRepository.Delete(author.Id);
                _genericBookAuthorCrudRepository.RollbackTransactionAsync();
                return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Fail, null);
            }
            if (createAuthorWithCross.CreateBookFromAuthor != null) await _genericBookAuthorCrudRepository.CommitTransactionAsync();
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);


        }
    }
}
