namespace MyServices.Web
{
    using System.ComponentModel.DataAnnotations;

    public class UserDTO : User
    {
        public UserDTO(string id, string name)
            : base(id, name)
        {
        }

        [Required]
        [Key]
        public override string Id
        {
            get { return base.Id; }
        }

        [Required]
        public override string Name
        {
            get { return base.Name; }
        }
    }
}