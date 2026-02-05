using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity?> GetByName(string name);
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteById(Guid id);
        Task<bool> DeleteByName(string name);
        Task<TEntity> Update(TEntity entity);
    }
}