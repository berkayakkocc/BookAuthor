using Core.Dtos.GenericDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterfaces.CrudInterfaces
{
    public interface IBasicCreateEntity<TInputEntity,TResponseEntity>
    {
        Task<GenericResponseDto<TResponseEntity>> CreateEntity(GenericInputDto<TInputEntity> tEntity);
    }
}
