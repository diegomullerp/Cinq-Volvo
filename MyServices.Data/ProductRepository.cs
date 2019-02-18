namespace MyServices.Data
{
    using System;
    using System.Linq;

    public class ProductRepository : JsonRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(string filePath) : base(filePath)
        {
        }

        public bool ContainsName(string name)
        {
            return GetAll().Any(product => product.Name.Equals(name));
        }
    }
}