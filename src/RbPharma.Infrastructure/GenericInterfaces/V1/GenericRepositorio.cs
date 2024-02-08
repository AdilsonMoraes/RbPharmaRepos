using Microsoft.EntityFrameworkCore;
using RbPharma.Domain.Entities.V1;
using RbPharma.Infrastructure.Contexts.V1;
using RbPharma.Infrastructure.GenericInterfaces.V1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RbPharma.Infrastructure.GenericInterfaces.V1
{
    public class GenericRepositorio<TEntity> : IGenericRepositorio<TEntity> where TEntity : BaseEntity
    {

        private readonly ContextSql _contextSql;
        private DbSet<TEntity> entities;
        string errorMessage = string.Empty;

        public GenericRepositorio(ContextSql contextSql)
        {
            _contextSql = contextSql;
            entities = contextSql.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entities.AsEnumerable().ToList();
        }
        public async Task<TEntity> GetById(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await _contextSql.SaveChangesAsync();
        }
        public async Task Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);
            await _contextSql.SaveChangesAsync();
        }
        public async Task Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await _contextSql.SaveChangesAsync();
        }
    }
}
