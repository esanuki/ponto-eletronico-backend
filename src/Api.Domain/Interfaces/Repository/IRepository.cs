using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> ObterPorId(Guid id);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> Salvar(T entity);
        Task<T> Atualizar(T entity);
        Task<bool> Remover(Guid id);
        Task<bool> Existe(Guid id);
    }
}
