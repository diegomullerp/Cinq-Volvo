namespace MyServices
{
    using System.Runtime.Serialization;
    using DomainServices;

    [DataContract]
    public class User : BaseEntity<string>
    {
        public User(string id, string name)
            : base(id, name)
        {
        }

        [DataMember]
        public virtual string Email { get; set; }
    }
}