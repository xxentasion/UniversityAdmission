using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Models
{
    public class Course
    {
        [Key]
        [MaxLength(20)]
        public string CourseID { get; set; }

        [Required, MaxLength(255)]
        public string CourseName { get; set; }

        [ForeignKey("Faculty")]
        public Guid FacultyID { get; set; }
        public Faculty Faculty { get; set; } // Навигационное свойство для связи с Faculty

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration in years must be greater than 0")]
        public int DurationInYears { get; set; }

        [Required]
        [MaxLength(50)]
        public string EducationLevel { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // Связь с InternalExamResults
        public ICollection<InternalExamResult> InternalExamResults { get; set; }

        // Связь с Applications
        public ICollection<Application> Applications { get; set; }
    }
}