namespace MyServices.Web
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductDTO : Product
    {
        public ProductDTO(string name)
            : base(name)
        {
        }

        [Required, Key]
        public override string Name
        {
            get { return base.Name; }
        }

        [Required, Range(1, Double.MaxValue)]
        public override decimal Price
        {
            get { return base.Price; }
            set { base.Price = value; }
        }
    }
}