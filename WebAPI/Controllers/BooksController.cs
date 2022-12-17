using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Book;
using Core.Interfaces.PageInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/booksController", Order = 0)]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost()]
        [Route("create-book")]
        public async Task<GenericResponseDto<NoContent>> CreateEntity([FromBody] GenericInputDto<CreateBookDto> tEntity)
        {
            return await _bookService.CreateEntity(tEntity);
        }
        [HttpDelete()]
        [Route("delete-book")]
        public async Task<GenericResponseDto<NoContent>> DeleteEntity([FromBody] GenericInputDto<DeleteBookDto> tEntity)
        {
            return await _bookService.DeleteEntity(tEntity);
        }
        [HttpPut()]
        [Route("update-book")]
        public async Task<GenericResponseDto<NoContent>> UpdateEntity([FromBody] GenericInputDto<UpdateBookDto> tEntity)
        {
            return await _bookService.UpdateEntity(tEntity);
        }
        [HttpPost()]
        [Route("get-all-book")]
        public GenericResponseDto<List<BookDto>> GetAllEntity(GenericInputDto<NoContent> tEntity)
        {
            return _bookService.GetAllEntity(tEntity);
        }
        [HttpGet()]
        [Route("get-by-id-book")]
        public Task<GenericResponseDto<BookDto>> GetByIdEntity(int id)
        {
            return _bookService.GetByIdEntity(id);
        }
    }
}
