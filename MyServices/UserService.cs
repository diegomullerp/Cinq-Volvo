namespace MyServices
{
    using System;
    using DomainServices;

    public class UserService : BaseService<User, string>
    {
        public UserService(IUserRepository repository)
            : base(repository)
        {
        }

        public override void Add(User user)
        {
            if (user.Name == null || user.Name.Equals(string.Empty))
            {
                throw new ArgumentException("User name cannot be null or empty string.", "user");
            }

            base.Add(user);
        }
    }
}