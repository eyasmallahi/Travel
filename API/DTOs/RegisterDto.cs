using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string phoneNumber { get; set; }
        [Required]

        public string Contry { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public int user_role { get; set; }

    }
}
