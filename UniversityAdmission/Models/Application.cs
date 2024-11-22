using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Models
{
    public class Application
    {
        [Key]
        public Guid ApplicationID { get; set; }

        [ForeignKey("Student")]
        [Required, MaxLength(20)]
        public string StudentID { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        [Required, MaxLength(20)]
        public string CourseID { get; set; }
        public Course Course { get; set; }

        [Required]
        public int PriorityOrder { get; set; }

        [ForeignKey("StudyForm")]
        public Guid StudyFormID { get; set; }
        public StudyForm StudyForm { get; set; }

        [ForeignKey("FinancingForm")]
        public Guid FinancingFormID { get; set; }
        public FinancingForm FinancingForm { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [Required, MaxLength(50)]
        public string Status { get; set; } = "Pending";
    }
}