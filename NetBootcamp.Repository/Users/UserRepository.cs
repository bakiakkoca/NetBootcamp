using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBootcamp.Repository.Users
{
    public class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
    {
        public async Task UpdateNameUser(string name, int id)
        {
            var user = await GetById(id);
            user!.Name = name;
            await Update(user);
        }
    }
}
