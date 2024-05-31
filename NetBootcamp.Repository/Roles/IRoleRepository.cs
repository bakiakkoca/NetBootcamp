using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Repository.Roles
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        public Task UpdateRoleName(string name, int id);
    }
}
