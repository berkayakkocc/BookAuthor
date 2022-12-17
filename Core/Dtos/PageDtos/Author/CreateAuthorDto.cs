using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageDtos.Author
{
    public class CreateAuthorDto
    {
        public CreateAuthorDto()
        {

        }
        public CreateAuthorDto(string firstName, string lastName, int age, int bornYear)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BornYear = bornYear;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int BornYear { get; set; }
    }
}
