using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Models
{
    public class FinancingForm
    {
        [Key]
        public Guid FinancingFormID { get; set; }

        [Required]
        public bool IsStateFunded { get; set; }

        // Связь с Applications
        public ICollection<Application> Applications { get; set; }
    }
}