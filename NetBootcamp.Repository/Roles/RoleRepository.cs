using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Repository.Roles
{
    public class RoleRepository(AppDbContext context) : GenericRepository<Role>(context), IRoleRepository
    {
        public async Task UpdateRoleName(string name, int id)
        {
            var role = await GetById(id);
            role!.Name = name;
            await Update(role);

        }
    }
}
