﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Core.Signatures;

namespace EShop.DataAccess.Repositories
{
    public interface IRepository<TEntity>
    where TEntity:class,IBaseEntity,new()
    {
        /// <summary>
        /// ToTable
        /// </summary>
        IQueryable<TEntity> Table { get; }
        
        /// <summary>
        /// To Table as No Tracking
        /// </summary>
        IQueryable<TEntity> AsNoTracking { get; }

        /// <summary>
        /// Any
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(int id);
        
        /// <summary>
        /// Get Entity By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id);
        
        /// <summary>
        /// Get Entity by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        
        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Delete Entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task DeleteRangeAsync(List<TEntity> entities);
    }
}