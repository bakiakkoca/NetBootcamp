using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Repository.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UpdateNameUser(string name, int id);
    }
}
