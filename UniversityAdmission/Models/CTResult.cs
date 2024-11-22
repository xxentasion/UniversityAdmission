using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Models
{
    public class CTResult
    {
        [Key]
        public Guid CTResultID { get; set; }

        [ForeignKey("Student")]
        [Required, MaxLength(20)]
        public string StudentID { get; set; }
        public Student Student { get; set; }

        [Required, MaxLength(100)]
        public string Subject { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }
    }
}