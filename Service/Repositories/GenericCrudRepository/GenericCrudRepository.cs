using AutoMapper;
using Core.Interfaces.GenericInterfaces;
using Core.Models.CommonEntity;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.GenericCrudRepository
{
    public class GenericCrudRepository<TEntity> : IGenericCrudRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly BookAuthorContext _context;
        private readonly IMapper _mapper;

        public GenericCrudRepository(BookAuthorContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region CrudOperation
        public async Task<TEntity> Insert(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = 1;
            EntityEntry x = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return (TEntity)x.Entity;
        }
        public async Task Delete(long id)
        {
            TEntity entity = await GetById(id);
            if (entity == null) return;

            entity.Deleted = 1;
            entity.DeleteDate = DateTime.Now;
            entity.DeletedBy = 1;
            await this.Update(entity);
        }
        public async Task Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = 1;

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Transactions
        public void CommitTransaction()
        {
            _context.SaveChanges();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public async void RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
        #endregion


        #region WithoutTransaction
        public async Task<TEntity> InsertWithoutTransaction(TEntity entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = 1;
                EntityEntry x = await _context.Set<TEntity>().AddAsync(entity);

                return (TEntity)x.Entity;
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
            return null;
        }
        public async Task DeleteWithoutTransaction(long id)
        {
            try
            {
                TEntity entity = await GetById(id);
                entity.Deleted = 1;
                entity.DeleteDate = DateTime.Now;
                entity.DeletedBy = 1;
                this.UpdateWithoutTransaction(entity);
               
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
        }
        public void UpdateWithoutTransaction(TEntity entity)
        {
            try
            {
                entity.UpdatedDate = DateTime.Now;
                entity.UpdatedBy = 1;

                _context.Set<TEntity>().Update(entity);
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }

        }

        #endregion

        #region Queries
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>()
                .Where(NonDeleted())
                .AsQueryable<TEntity>(); ;

        }

        public async Task<TEntity> GetById(long id) => await _context.Set<TEntity>()
                                                                   .Where(NonDeleted())
                                                                   .AsNoTracking()
                                                                   .FirstOrDefaultAsync(x => x.Id == id);
        #endregion








        public Expression<Func<TEntity, bool>> NonDeleted()
        {
            return tEntity => tEntity.Deleted != 1;
        }

        

       

       
    }
}
