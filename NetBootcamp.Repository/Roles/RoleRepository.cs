namespace NetBootcamp.Repository.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private static List<Role> _roles =
        [
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "Member" },
        ];


        public IReadOnlyList<Role> GetAll() => _roles;

        public void Create(Role role)
        {
            _roles.Add(role);

        }

        public void Update(Role role)
        {
            var index = _roles.FindIndex(x => x.Id == role.Id);
            _roles[index] = role;
        }

        public void Delete(int id)
        {
            var role = GetById(id);
            _roles.Remove(role!);
        }

        public Role? GetById(int id) => _roles.Find(x => x.Id == id);
    }
}
