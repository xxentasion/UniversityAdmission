using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Models
{
    public class Student
    {
        [Key]
        [MaxLength(20)]
        public string StudentID { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        // Связь с Applications
        public ICollection<Application> Applications { get; set; }

        // Связь с InternalExamResults
        public ICollection<InternalExamResult> InternalExamResults { get; set; }

        // Связь с OlympiadAchievements
        public ICollection<OlympiadAchievement> OlympiadAchievements { get; set; }

        // Связь с CTResults
        public ICollection<CTResult> CTResults { get; set; }

        // Связь с SocialStatus
        public SocialStatus SocialStatus { get; set; }
    }
}