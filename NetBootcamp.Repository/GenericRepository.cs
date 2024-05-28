using Microsoft.EntityFrameworkCore;

namespace NetBootcamp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity<int>
    {
        public DbSet<T> DbSet { get; set; }
        protected AppDbContext Context;

        public GenericRepository(AppDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            var list = await DbSet.ToListAsync();
            return list.AsReadOnly();
        }

        public Task Update(T entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            DbSet.Remove(entity!);
        }

        public async Task<T> Create(T entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T?> GetById(int id)
        {
            var result = await DbSet.FindAsync(id);
            return result;
        }

        public Task<bool> HasExist(int id)
        {
            return DbSet.AnyAsync(x => x.Id == id);
        }
    }
}
