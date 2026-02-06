namespace RailCarTrip.Interface
{
    public interface IEquipmentEventImportService
    {
        Task<List<EquipmentEvent>> ImportAsync(Stream fileStream, string fileName);
    }
}
