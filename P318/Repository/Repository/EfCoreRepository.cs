using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Base;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository.Contracts;

namespace Repository.Repository
{
    public class EfCoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext Db;

        public EfCoreRepository(AppDbContext db)
        {
            Db = db;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Db.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> expression, IList<string> includedProperties = null)
        {
            IQueryable<T> data = Db.Set<T>();

            if (includedProperties != null)
            {
                foreach (var includedProperty in includedProperties)
                {
                    data = data.Include(includedProperty);
                }
            }

            data = data.Where(expression);

            return await data.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Db.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AddAsync(T item)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                await Db.Set<T>().AddAsync(item);
                await Db.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> AddAsync(IEnumerable<T> items)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in items)
                {
                    await Db.Set<T>().AddAsync(item);
                    await Db.SaveChangesAsync();
                }
                
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> AddAsync(params T[] items)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in items)
                {
                    await Db.Set<T>().AddAsync(item);
                    await Db.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(T item)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                Db.Set<T>().Update(item);
                await Db.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(IEnumerable<T> items)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in items)
                {
                    Db.Set<T>().Update(item);
                    await Db.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(params T[] items)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in items)
                {
                    Db.Set<T>().Update(item);
                    await Db.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T item)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                Db.Set<T>().Remove(item);
                await Db.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(IEnumerable<T> items)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in items)
                {
                    Db.Set<T>().Remove(item);
                    await Db.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(params T[] items)
        {
            await using var transaction = await Db.Database.BeginTransactionAsync();

            try
            {
                foreach (var item in items)
                {
                    Db.Set<T>().Remove(item);
                    await Db.SaveChangesAsync();
                }

                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
