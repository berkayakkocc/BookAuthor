using AutoMapper;
using Core.Dtos.Constants;
using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Book;
using Core.Interfaces.GenericInterfaces;
using Core.Interfaces.PageInterfaces;
using Core.Models.PageEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService : IBookService
    {
        private readonly IGenericCrudRepository<Book> _genericBookCrudRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericCrudRepository<Book> genericBookCrudRepository, IMapper mapper)
        {
            _genericBookCrudRepository = genericBookCrudRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponseDto<NoContent>> CreateEntity(GenericInputDto<CreateBookDto> tEntity)
        {
            Book book = _mapper.Map<Book>(tEntity.Data);
            await _genericBookCrudRepository.Insert(book);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> DeleteEntity(GenericInputDto<DeleteBookDto> tEntity)
        {
            await _genericBookCrudRepository.Delete((long)tEntity.Data.Id);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);
        }

        public GenericResponseDto<List<BookDto>> GetAllEntity(GenericInputDto<NoContent> tEntity)
        {
            List<Book> resultValues = _genericBookCrudRepository.GetAll()
                       .Include(x => x.Author)
                      
                          .ToList<Book>();

            var mappedResult = _mapper.Map<List<BookDto>>(resultValues);
            return GenericResponseDto<List<BookDto>>.ResponseData(mappedResult, (int)ErrorEnum.Success, null);
        }

        public async Task<GenericResponseDto<BookDto>> GetByIdEntity(int id)
        {
            Book result = await _genericBookCrudRepository.GetById(id);


            return GenericResponseDto<BookDto>.ResponseData(_mapper.Map<BookDto>(result), (int)ErrorEnum.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> UpdateEntity(GenericInputDto<UpdateBookDto> tEntity)
        {
            Book book = _mapper.Map<Book>(tEntity.Data);
            await _genericBookCrudRepository.Update(book);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnum.Success, null);
        }
    }
}
