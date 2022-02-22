using Curso.Data;
using Microsoft.EntityFrameworkCore;
using PedidoConsole.Domain;
using PedidoConsole.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoConsole
{
    public class GenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbSet;

        public GenericRepository(DbContext applicationContext)
        {
            _dbSet = applicationContext;
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.Set<TEntity>().AddAsync(entity);
        }

        public IQueryable<TEntity> GetById(int id)
        {
            return _dbSet.Set<TEntity>().AsNoTracking()
                .Where(e => e.Id == id);
        }
        
    }
}
