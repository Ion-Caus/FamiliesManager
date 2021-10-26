using System.ComponentModel.DataAnnotations;

namespace FamilyManager_WebApi.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public string HairColor { get; set; }
        
        public string EyeColor { get; set; }
        
        [Required]
        [Range(0,120, ErrorMessage = "Invalid age provided.")]
        public int Age { get; set; }
        
        [Range(0,230, ErrorMessage = "Invalid weight provided.")]
        public float Weight { get; set; }
        
        [Range(0,230, ErrorMessage = "Invalid height provided.")]
        public int Height { get; set; }
        
        [Required]
        public string Sex { get; set; }
    }
}