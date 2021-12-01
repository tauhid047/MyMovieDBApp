using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovieDBApp.Models
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
        [Required]
        public string KeyWord { get; set; }
    }
}
