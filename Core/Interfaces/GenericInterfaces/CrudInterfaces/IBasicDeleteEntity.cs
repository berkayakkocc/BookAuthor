using Core.Dtos.GenericDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterfaces.CrudInterfaces
{
    public interface IBasicDeleteEntity<TInputEntity,TResponseEntity>
    {
        Task<GenericResponseDto<TResponseEntity>> DeleteEntity(GenericInputDto<TInputEntity> tEntity);
    }
}
