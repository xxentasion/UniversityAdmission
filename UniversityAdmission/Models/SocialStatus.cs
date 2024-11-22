using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAdmission.Models
{
    public class SocialStatus
    {
        [Key]
        public Guid SocialStatusID { get; set; }

        [ForeignKey("Student")]
        [Required, MaxLength(20)]
        public string StudentID { get; set; }
        public Student Student { get; set; }

        [Required]
        public bool IsLargeFamily { get; set; }

        [Required]
        public bool HasSingleParent { get; set; }

        [Required]
        public bool HasNoParents { get; set; }
    }
}