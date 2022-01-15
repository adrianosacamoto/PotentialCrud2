using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PotentialCrud2.Domain.Entities;

namespace PotentialCrud2.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
        Task<IEnumerable<T>> SelectAsync(string nome, int skip, int take);
        Task<bool> ExistAsync(Guid id);
    }
}
