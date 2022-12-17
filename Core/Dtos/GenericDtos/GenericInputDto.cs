using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.GenericDtos
{
    public class GenericInputDto<T>
    {
        public GenericInputDto()
        {

        }
        public T? Data { get; set; }

        public static GenericInputDto<T> ResponseData(T? data)
        {
            return new GenericInputDto<T> { Data = data };
        }
    }
}
