using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(10, ErrorMessage = "Name is invalid length")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10)]
        public required string Password { get; set; }
    }
}