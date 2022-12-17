using Core.Models.CommonEntity;

namespace Core.Models.PageEntity
{
    public class Book : BaseEntity
    {
        public Book()
        {


        }
        public Book(string name, int pageNumber, int yearOfWrite, string type)
        {
            Name = name;
            PageNumber = pageNumber;
            YearOfWrite = yearOfWrite;
            Type = type;
        }

        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int YearOfWrite { get; set; }
        public string Type { get; set; }
        public long AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}


/* Kitabın Neyi olur
 * Name
 * Yazıldığı tarih
 * NumOfPages  sayfa sayısı
 * Tür
 * Author 1-n
 * 
 * Bir kitabın bir yazarı olur.
 * Bir yazarın bir çok kitabı olur.
 */