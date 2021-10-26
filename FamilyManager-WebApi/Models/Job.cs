using System.ComponentModel.DataAnnotations;

namespace FamilyManager_WebApi.Models
{
    public class Job
    {
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Salary provided.")]
        public int Salary { get; set; }
    }
}