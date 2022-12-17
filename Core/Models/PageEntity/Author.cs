using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.PageEntity
{
    public class Author:BaseEntity
    {
        public Author()
        {

        }

        public Author(string firstName, string lastName, int age, int bornYear, ICollection<BookAuthor> bookAuthors)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BornYear = bornYear;
            BookAuthors = bookAuthors;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int BornYear { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
