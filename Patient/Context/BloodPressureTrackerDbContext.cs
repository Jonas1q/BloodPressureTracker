namespace Patient.Context;

using Microsoft.EntityFrameworkCore;
using Models;
public class BloodPressureTrackerDbContext : DbContext
{
    public BloodPressureTrackerDbContext(DbContextOptions<BloodPressureTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<PatientModel> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
