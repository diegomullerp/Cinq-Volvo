namespace MyServices.Web.DTOs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdatedProductDTO
    {
        [Required]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }

        public Product ToProduct()
        {
            return new Product(Id, Name) { Price = Price };
        }
    }
}