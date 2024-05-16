namespace NetBootcamp.API.Users
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users =
        [
            new User {  Id = 1, Name = "Mehmet", Surname = "Tuna", Email = "mehmettuna@gmail.com" },
            new User {  Id = 2, Name = "Canan", Surname = "Akın", Email = "cananakın@gmail.com" }
        ];

        public IReadOnlyList<User> GetAll() => _users;

        public void Update(User user)
        {
            var index = _users.FindIndex(x => x.Id == user.Id);
            _users[index] = user;
        }

        public void Create(User user)
        {
            var methodName = nameof(UsersController.GetById);
            _users.Add(user);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _users.Remove(user!);
        }

        public User? GetById(int id) => _users.Find(x => x.Id == id);
    }
}
