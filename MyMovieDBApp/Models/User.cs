using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovieDBApp.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Maximum 20 characters allowed")]
        public string FirstName { get; set; }

        [MaxLength(10, ErrorMessage = "Maximum 10 characters allowed")]
        public string MiddleName { get; set; }
        
        [Required]
        [MaxLength(15, ErrorMessage = "Maximum 15 characters allowed")]
        public string LastName { get; set; }
    }
}
