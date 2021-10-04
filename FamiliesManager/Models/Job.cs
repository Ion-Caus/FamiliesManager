using System;
using System.ComponentModel.DataAnnotations;

namespace FamiliesManager.Models
{
    public class Job
    {
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Salary provided.")]
        public int Salary { get; set; }
    }
}