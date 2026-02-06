using RailCarAPI.Interface;



public class EquipmentEventRepository : IEquipmentEventRepository
{
    private readonly TripDbContext _context;

    public EquipmentEventRepository(TripDbContext context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(IEnumerable<EquipmentEvent> events)
    {
        await _context.EquipmentEvents.AddRangeAsync(events);
        await _context.SaveChangesAsync();
    }
}