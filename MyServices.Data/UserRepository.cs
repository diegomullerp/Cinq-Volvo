namespace MyServices.Data
{
    public class UserRepository : JsonRepository<User, string>, IUserRepository
    {
        public UserRepository(string filePath) : base(filePath)
        {
        }
    }
}