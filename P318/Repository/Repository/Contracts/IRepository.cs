using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Base;

namespace Repository.Repository.Contracts
{
    public interface IRepository<T> where T: class, IEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression, IList<string> includedProperties = null);
        Task<T> GetAsync(int id);
        Task<bool> AddAsync(T item);
        Task<bool> AddAsync(IEnumerable<T> items);
        Task<bool> AddAsync(params T[] items);
        Task<bool> UpdateAsync(T item);
        Task<bool> UpdateAsync(IEnumerable<T> items);
        Task<bool> UpdateAsync(params T[] items);
        Task<bool> DeleteAsync(T item);
        Task<bool> DeleteAsync(IEnumerable<T> items);
        Task<bool> DeleteAsync(params T[] items);
    }
}
