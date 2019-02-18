namespace MyServices.Web.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public struct ProductDTO
    {
        public Guid Id { get; set; }

        [Required, Key]
        public string Name { get; set; }

        [Required, Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        public Product ToProduct()
        {
            return new Product(Guid.NewGuid(), Name) { Price = Price };
        }
    }
}