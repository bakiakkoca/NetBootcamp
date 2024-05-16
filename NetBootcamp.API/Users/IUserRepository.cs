namespace NetBootcamp.API.Users
{
    public interface IUserRepository
    {
        IReadOnlyList<User> GetAll();

        void Update(User user);
        void Create(User user);
        void Delete(int id);

        User? GetById(int id);
    }
}
