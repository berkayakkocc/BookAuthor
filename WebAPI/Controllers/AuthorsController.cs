using Core.Dtos.GenericDtos;
using Core.Dtos.PageDtos.Author;
using Core.Interfaces.PageInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/authorsController", Order = 0)]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost()]
        [Route("create-author")]
        public async Task<GenericResponseDto<NoContent>> CreateEntity([FromBody] GenericInputDto<CreateAuthorDto> tEntity)
        {
            return await _authorService.CreateEntity(tEntity);
        }
        [HttpDelete()]
        [Route("delete-author")]
        public async Task<GenericResponseDto<NoContent>> DeleteEntity([FromBody] GenericInputDto<DeleteAuthorDto> tEntity)
        {
            return await _authorService.DeleteEntity(tEntity);
        }
        [HttpPut()]
        [Route("update-author")]
        public async Task<GenericResponseDto<NoContent>> UpdateEntity([FromBody] GenericInputDto<UpdateAuthorDto> tEntity)
        {
            return await _authorService.UpdateEntity(tEntity);
        }
        [HttpPost()]
        [Route("get-all-author")]
        public GenericResponseDto<List<AuthorDto>> GetAllEntity(GenericInputDto<NoContent> tEntity)
        {
            return _authorService.GetAllEntity(tEntity);
        }
        [HttpGet()]
        [Route("get-by-id-book")]
        public Task<GenericResponseDto<AuthorDto>> GetByIdEntity(int id)
        {
            return _authorService.GetByIdEntity(id);
        }
    }
}
