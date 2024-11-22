using Microsoft.EntityFrameworkCore;
using UniversityAdmission.Models;

namespace UniversityAdmission.Data
{
    public class UniversityContext(DbContextOptions<UniversityContext> options) : DbContext(options)
    {
        // Определение таблиц в контексте
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CTResult> CTResults { get; set; }
        public DbSet<InternalExamResult> InternalExamResults { get; set; }
        public DbSet<OlympiadAchievement> OlympiadAchievements { get; set; }
        public DbSet<SocialStatus> SocialStatuses { get; set; }
        public DbSet<StudyForm> StudyForms { get; set; }
        public DbSet<FinancingForm> FinancingForms { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
