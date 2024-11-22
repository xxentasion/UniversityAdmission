using System.ComponentModel.DataAnnotations;

namespace UniversityAdmission.Models.DTO
{
    public class StudentRequest
    {
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
    }
}
