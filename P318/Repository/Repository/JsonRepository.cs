using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Base;
using Repository.Repository.Contracts;

namespace Repository.Repository
{
    public class JsonRepository<T> : IRepository<T> where T: class, IEntity
    {
        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression, IList<string> includedProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddAsync(params T[] items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(params T[] items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(params T[] items)
        {
            throw new NotImplementedException();
        }
    }
}
