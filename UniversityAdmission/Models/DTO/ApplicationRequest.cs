namespace UniversityAdmission.Models.DTO
{
    public class ApplicationRequest
    {
        public string StudentID { get; set; }
        public string CourseID { get; set; }
        public Guid StudyFormID { get; set; }
        public Guid FinancingFormID { get; set; }
        public int PriorityOrder { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending";
    }
}