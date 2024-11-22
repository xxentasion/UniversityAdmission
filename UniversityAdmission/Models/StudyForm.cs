using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Models
{
    public class StudyForm
    {
        [Key]
        public Guid StudyFormID { get; set; }

        [Required]
        public bool IsFullForm { get; set; }

        // Связь с Applications
        public ICollection<Application> Applications { get; set; }
    }
}