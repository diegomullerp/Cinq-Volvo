namespace MyServices
{
    using DomainServices;

    public interface IUserRepository : IRepository<User, string>
    {
    }
}