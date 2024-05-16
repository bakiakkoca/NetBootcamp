namespace NetBootcamp.API.Roles
{
    public interface IRoleRepository
    {
        IReadOnlyList<Role> GetAll();

        void Create(Role role);
        void Update(Role role);
        void Delete(int id);

        Role? GetById(int id);
    }
}
