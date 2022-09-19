using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; } = 1;
    }
}
