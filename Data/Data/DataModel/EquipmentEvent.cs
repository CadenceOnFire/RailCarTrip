using System;

public class EquipmentEvent
{
    public int EquipmentId { get; set; }
    public string EventCode { get; set; } = null!;
    public DateTime EventTime { get; set; }

    public int CityId { get; set; }

    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }
}