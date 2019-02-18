namespace MyServices.Web
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdatedProductDTO : ProductDTO
    {
        public UpdatedProductDTO(string name)
            : base(name)
        {
        }

        [Required]
        public override Guid Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }
}