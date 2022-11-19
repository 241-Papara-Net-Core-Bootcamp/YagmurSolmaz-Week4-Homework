using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace Entry.Data.Abstracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> Delete(string name);
        Task<int> Update(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(string name);
    }
}