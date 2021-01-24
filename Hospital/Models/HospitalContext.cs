using Microsoft.EntityFrameworkCore;

namespace Hospital.Models
{
    public class HospitalContext : DbContext
    {
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Deseases> Deseases { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
