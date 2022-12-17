namespace Core.Dtos.PageDtos.Book
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int YearOfWrite { get; set; }
        public string Type { get; set; }
        public long AuthorId { get; set; }
    }
}
