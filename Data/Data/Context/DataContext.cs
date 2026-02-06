using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class TripDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; } = null!;
    public DbSet<EquipmentEvent> EquipmentEvents { get; set; } = null!;
    public TripDbContext(DbContextOptions<TripDbContext> options)
        : base(options)
    {
    }
     

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentEvent>(entity =>
        {
            entity.ToTable("EquipmentEvent");

            entity.HasKey(e => new { e.EquipmentId, e.EventTime });

            entity.Property(e => e.EquipmentId)
                  .HasColumnName("equipmentid");

            entity.Property(e => e.EventCode)
                  .HasColumnName("eventcode")
                  .HasMaxLength(50)
                  .IsRequired();

            entity.Property(e => e.EventTime)
                  .HasColumnName("eventtime")
                  .IsRequired();

            entity.Property(e => e.CityId)
                  .HasColumnName("cityid");

            entity.Property(e => e.CreatedDate)
                  .HasColumnName("createddate")
                  .IsRequired();

            entity.Property(e => e.CreatedBy)
                  .HasColumnName("createdby")
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.ModifiedDate)
                  .HasColumnName("modifieddate");

            entity.Property(e => e.ModifiedBy)
                  .HasColumnName("modifiedby")
                  .HasMaxLength(100);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.ToTable("Trip");

            entity.HasKey(t => t.TripId);

            entity.Property(t => t.TripId)
                  .HasColumnName("tripid");

            entity.Property(t => t.EquipmentId)
                  .HasColumnName("equipmentid")
                  .IsRequired();

            entity.Property(t => t.OriginCityId)
                  .HasColumnName("origincityid")
                  .IsRequired();

            entity.Property(t => t.DestinationCityId)
                  .HasColumnName("destinationcityid")
                  .IsRequired();

            entity.Property(t => t.StartUtc)
                  .HasColumnName("startutc")
                  .IsRequired();

            entity.Property(t => t.EndUtc)
                  .HasColumnName("endutc")
                  .IsRequired();

            entity.Property(t => t.TotalTripHours)
                  .HasColumnName("totaltriphours")
                  .HasColumnType("decimal(10,2)");
        });
    }
}