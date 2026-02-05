
using E_Commerce.Domain;
using E_Commerce.Domain.IRepository;
using E_Commerce.Infreastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infreastructure.Repository
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            try
            {
                var entity = await context.Set<TEntity>().FindAsync(id);

                if (entity == null)
                {
                    return false;
                }

                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteByName(string name)
        {
            try
            {
                var entity = await context.Set<TEntity>()
                    .FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);

                if (entity == null)
                {
                    return false;
                }

                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {

            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByName(string name)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(e => EF.Property<string>(e, "Name") == name);

        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
