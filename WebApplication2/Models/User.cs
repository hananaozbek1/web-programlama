using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyLife.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
