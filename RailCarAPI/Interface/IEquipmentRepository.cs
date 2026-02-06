namespace RailCarAPI.Interface
{
    public interface IEquipmentEventRepository
    {
        public Task AddRangeAsync(IEnumerable<EquipmentEvent> events);

    }
}