using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Models
{
    public class OlympiadAchievement
    {
        [Key]
        public Guid AchievementID { get; set; }

        [ForeignKey("Student")]
        [Required, MaxLength(20)]
        public string StudentID { get; set; }
        public Student Student { get; set; }

        [Required, MaxLength(255)]
        public string OlympiadName { get; set; }

        [Range(1900, int.MaxValue)]
        public int Year { get; set; }
    }
}