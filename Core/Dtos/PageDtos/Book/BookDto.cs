using Core.Models.CommonEntity;

namespace Core.Dtos.PageDtos.Book
{
    public class BookDto : BaseEntity
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int YearOfWrite { get; set; }
        public string Type { get; set; }
        public long AuthorId { get; set; }
    }
}
