using System.ComponentModel.DataAnnotations;

namespace FamilyManager_WebApi.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Salary provided.")]
        public int Salary { get; set; }
    }
}