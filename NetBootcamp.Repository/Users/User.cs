namespace NetBootcamp.Repository.Users
{
    public class User : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Email { get; set; } = default!;

        public DateTime Created { get; set; } = new();

    }
}
