using Core.Dtos.GenericDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterfaces.CrudInterfaces
{
    public interface IBasicGetAllEntity<TInputEntity, TResponseEntity>
    {
        GenericResponseDto<TResponseEntity> GetAllEntity(GenericInputDto<TInputEntity> tEntity);

    }
}
