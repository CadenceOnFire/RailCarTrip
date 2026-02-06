using System;

public class Trip
{
    public int TripId { get; set; }   // Primary Key

    public int EquipmentId { get; set; }

    public int OriginCityId { get; set; }
    public int DestinationCityId { get; set; }

    public DateTime StartUtc { get; set; }
    public DateTime EndUtc { get; set; }

    //public decimal TotalTripHours { get; set; }
    public decimal TotalTripHours =>
    (decimal)(EndUtc - StartUtc).TotalHours;
   
}