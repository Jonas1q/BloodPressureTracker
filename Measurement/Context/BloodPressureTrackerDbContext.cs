namespace Measurement.Context;
using Microsoft.EntityFrameworkCore;
using Measurement.Models;


public class BloodPressureTrackerDbContext : DbContext
{
    public BloodPressureTrackerDbContext(DbContextOptions<BloodPressureTrackerDbContext> options) : base(options)
    {
    }

    public DbSet<MeasurementModel> Measurements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}