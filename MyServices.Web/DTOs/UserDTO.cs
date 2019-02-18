namespace MyServices.Web.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public struct UserDTO
    {
        [Required, Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        public User ToUser()
        {
            return new User(Id, Name) { Email = Email };
        }
    }
}