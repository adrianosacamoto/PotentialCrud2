using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PotentialCrud2.Data.Context;
using PotentialCrud2.Domain.Entities;
using PotentialCrud2.Domain.Interfaces;

namespace PotentialCrud2.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataSet;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.DataHoraInclusao = DateTime.UtcNow;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync(string nome, int skip, int take)
        {
            try
            {
                var desenvolvedores = from d in _context.Desenvolvedor select d;

                if (desenvolvedores != null)
                {
                    desenvolvedores = desenvolvedores
                                        .Where(x => x.Nome.Contains(nome));
                }

                return (IEnumerable<T>)await desenvolvedores
                                                .AsNoTracking()
                                                .Skip(skip)
                                                .Take(take)
                                                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(item.Id));
                if (result == null)
                    return null;

                item.DataHoraAlteracao = DateTime.UtcNow;
                item.DataHoraInclusao = result.DataHoraInclusao;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
