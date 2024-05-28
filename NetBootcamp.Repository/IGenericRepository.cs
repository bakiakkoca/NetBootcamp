using NetBootcamp.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IReadOnlyList<T>> GetAll();

        Task Update(T entity);
        Task Delete(int id);

        Task<T> Create(T entity);
        Task<T?> GetById(int id);

        Task<bool> HasExist(int id);

    }
}
