using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterfaces
{
    public interface IGenericCrudRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(long id);
        Expression<Func<TEntity, bool>> NonDeleted();
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> InsertWithoutTransaction(TEntity entity);
        Task Update(TEntity entity);
        void UpdateWithoutTransaction(TEntity entity);
        Task Delete(long id);
        Task DeleteWithoutTransaction(long id);
        void CommitTransaction();
        Task CommitTransactionAsync();
        void RollbackTransactionAsync();
        void RollbackTransaction();
    }
}
