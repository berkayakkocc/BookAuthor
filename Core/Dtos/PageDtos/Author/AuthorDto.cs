using Core.Dtos.PageDtos.Book;
using Core.Models.CommonEntity;

namespace Core.Dtos.PageDtos.Author
{
    public class AuthorDto : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int BornYear { get; set; }
        public virtual List<BookNavigationDto> BookNavigations { get; set; }
    }
}
