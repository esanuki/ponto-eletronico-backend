using Api.Data.Context;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        public readonly PontoEletronicoContext _context;
        public DbSet<T> dbSet;

        public Repository(PontoEletronicoContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }


        public async Task<T> ObterPorId(Guid id)
        {
            try
            {
                return await dbSet.SingleOrDefaultAsync<T>(t => t.Id.Equals(id));

            } catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            try
            {
                return await dbSet.ToListAsync();

            } catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<T> Salvar(T entity)
        {
            try 
            {
                entity.Id = new Guid();
                dbSet.Add(entity);

                await _context.SaveChangesAsync();

                return await ObterPorId(entity.Id);

            } catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<T> Atualizar(T entity)
        {
            try
            {
                dbSet.Update(entity);

                await _context.SaveChangesAsync();

                return await ObterPorId(entity.Id);

            } catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<bool> Remover(Guid id)
        {
            try
            {
                var entity = await ObterPorId(id);

                if (entity != null)
                {
                    dbSet.Remove(entity);
                    await _context.SaveChangesAsync();

                    return true;

                }

                return false;

            } catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<bool> Existe(Guid id)
        {
            try
            {
                return await dbSet.AnyAsync(t => t.Id.Equals(id));

            } catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
