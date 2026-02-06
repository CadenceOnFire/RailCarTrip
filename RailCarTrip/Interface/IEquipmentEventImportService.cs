using RailCarTrip.ViewModel;

namespace RailCarTrip.Interface
{
    public interface IEquipmentEventImportService
    {
        Task<List<EquipmentEvent>> ImportAsync(string fileName);
        List<TripEventsVModel> CreateTripsFromEvents(List<EquipmentEvent> events);
    }
}
