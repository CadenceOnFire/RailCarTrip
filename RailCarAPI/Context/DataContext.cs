using Common.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class TripDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; } = null!;
    public DbSet<EquipmentEvent> EquipmentEvents => Set<EquipmentEvent>();
    public DbSet<City> Cities { get; set; } = null!;

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

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Vancouver", TimeZone = "Pacific Standard Time" },
            new City { Id = 2, Name = "Victoria", TimeZone = "Pacific Standard Time" },
            new City { Id = 3, Name = "Kelowna", TimeZone = "Pacific Standard Time" },
            new City { Id = 4, Name = "Kamloops", TimeZone = "Pacific Standard Time" },
            new City { Id = 5, Name = "Prince George", TimeZone = "Pacific Standard Time" },

            new City { Id = 6, Name = "Calgary", TimeZone = "Mountain Standard Time" },
            new City { Id = 7, Name = "Edmonton", TimeZone = "Mountain Standard Time" },
            new City { Id = 8, Name = "Lethbridge", TimeZone = "Mountain Standard Time" },
            new City { Id = 9, Name = "Red Deer", TimeZone = "Mountain Standard Time" },
            new City { Id = 10, Name = "Fort McMurray", TimeZone = "Mountain Standard Time" },

            new City { Id = 11, Name = "Regina", TimeZone = "Canada Central Standard Time" },
            new City { Id = 12, Name = "Saskatoon", TimeZone = "Canada Central Standard Time" },
            new City { Id = 13, Name = "Moose Jaw", TimeZone = "Canada Central Standard Time" },

            new City { Id = 14, Name = "Brandon", TimeZone = "Central Standard Time" },
            new City { Id = 15, Name = "Winnipeg", TimeZone = "Central Standard Time" },

            new City { Id = 16, Name = "Thunder Bay", TimeZone = "Eastern Standard Time" },
            new City { Id = 17, Name = "Sault Ste. Marie", TimeZone = "Eastern Standard Time" },
            new City { Id = 18, Name = "Sudbury", TimeZone = "Eastern Standard Time" },
            new City { Id = 19, Name = "North Bay", TimeZone = "Eastern Standard Time" },
            new City { Id = 20, Name = "Barrie", TimeZone = "Eastern Standard Time" },
            new City { Id = 21, Name = "Toronto", TimeZone = "Eastern Standard Time" },
            new City { Id = 22, Name = "Mississauga", TimeZone = "Eastern Standard Time" },
            new City { Id = 23, Name = "Hamilton", TimeZone = "Eastern Standard Time" },
            new City { Id = 24, Name = "London", TimeZone = "Eastern Standard Time" },
            new City { Id = 25, Name = "Kitchener", TimeZone = "Eastern Standard Time" },
            new City { Id = 26, Name = "Windsor", TimeZone = "Eastern Standard Time" },
            new City { Id = 27, Name = "St. Catharines", TimeZone = "Eastern Standard Time" },
            new City { Id = 28, Name = "Oshawa", TimeZone = "Eastern Standard Time" },
            new City { Id = 29, Name = "Kingston", TimeZone = "Eastern Standard Time" },
            new City { Id = 30, Name = "Ottawa", TimeZone = "Eastern Standard Time" },
            new City { Id = 31, Name = "Gatineau", TimeZone = "Eastern Standard Time" },
            new City { Id = 32, Name = "Montreal", TimeZone = "Eastern Standard Time" },
            new City { Id = 33, Name = "Quebec City", TimeZone = "Eastern Standard Time" },
            new City { Id = 34, Name = "Sherbrooke", TimeZone = "Eastern Standard Time" },
            new City { Id = 35, Name = "Trois-Rivières", TimeZone = "Eastern Standard Time" },
            new City { Id = 36, Name = "Saguenay", TimeZone = "Eastern Standard Time" },
            new City { Id = 37, Name = "Rimouski", TimeZone = "Eastern Standard Time" },

            new City { Id = 38, Name = "Edmundston", TimeZone = "Atlantic Standard Time" },
            new City { Id = 39, Name = "Fredericton", TimeZone = "Atlantic Standard Time" },
            new City { Id = 40, Name = "Moncton", TimeZone = "Atlantic Standard Time" },
            new City { Id = 41, Name = "Saint John", TimeZone = "Atlantic Standard Time" },
            new City { Id = 42, Name = "Bathurst", TimeZone = "Atlantic Standard Time" },
            new City { Id = 43, Name = "Charlottetown", TimeZone = "Atlantic Standard Time" },
            new City { Id = 44, Name = "Summerside", TimeZone = "Atlantic Standard Time" },
            new City { Id = 45, Name = "Sydney", TimeZone = "Atlantic Standard Time" },
            new City { Id = 46, Name = "Truro", TimeZone = "Atlantic Standard Time" },
            new City { Id = 47, Name = "New Glasgow", TimeZone = "Atlantic Standard Time" },
            new City { Id = 48, Name = "Dartmouth", TimeZone = "Atlantic Standard Time" },
            new City { Id = 49, Name = "Halifax", TimeZone = "Atlantic Standard Time" }
        );
    }
}