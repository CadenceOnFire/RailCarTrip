namespace RailCarTrip.ViewModel
{
    public class TripEventsVModel
    {
        public int TripId { get; set; }
        public List<EquipmentEventVModel> EquipmentEvents { get; set; } = new List<EquipmentEventVModel>();
    }
}
