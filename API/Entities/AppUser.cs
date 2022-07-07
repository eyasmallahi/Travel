using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser
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
        public byte[] HashPassword { get; set; }
        [Required]

        public byte[] SaltPassword { get; set; }
        [Required]
        public string UserType { get; set; }
       
        public string TravelID { get; set; }

        public Travel Travel { get; set; }






    }
}
