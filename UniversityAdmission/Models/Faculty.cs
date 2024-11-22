using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Models
{
    public class Faculty
    {
        [Key]
        public Guid FacultyID { get; set; }

        [Required, MaxLength(255)]
        public string FacultyName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        // Связь один-ко-многим с курсами
        public ICollection<Course> Courses { get; set; }
    }
}