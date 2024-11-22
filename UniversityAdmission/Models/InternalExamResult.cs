using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Models
{
    public class InternalExamResult
    {
        [Key]
        public Guid InternalExamResultID { get; set; }

        [ForeignKey("Student")]
        [Required, MaxLength(20)]
        public string StudentID { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        [Required, MaxLength(20)]
        public string CourseID { get; set; }
        public Course Course { get; set; }

        [Required, MaxLength(255)]
        public string ExamName { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }
    }
}