namespace MyServices
{
    using System;
    using System.Runtime.Serialization;
    using DomainServices;

    [DataContract]
    public class Product : BaseEntity<Guid>
    {
        public Product(Guid id, string name)
            : base(id, name)
        {
        }

        [DataMember]
        public virtual decimal Price { get; set; }
    }
}