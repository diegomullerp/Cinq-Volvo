namespace MyServices
{
    using System;
    using DomainServices;

    public interface IProductRepository : IRepository<Product, Guid>
    {
        bool ContainsName(string name);
    }
}