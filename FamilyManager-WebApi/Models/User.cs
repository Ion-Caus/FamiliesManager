using System.ComponentModel.DataAnnotations;

namespace FamilyManager_WebApi.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}