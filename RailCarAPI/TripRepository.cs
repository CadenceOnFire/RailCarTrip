using Microsoft.EntityFrameworkCore;
using RailCarAPI.Interface;


public class TripRepository: ITripRepository<Trip>
{ 
    protected readonly TripDbContext _context;

    public TripRepository(TripDbContext context)
    {
        _context = context; 
    }

    // Simulate a delay for async operations
    private Task SimulateAsyncDelay()
    {
        return Task.Delay(100); // 100ms delay for async simulation
    } 
 
    public async Task<Trip> GetTripByIdAsync(int id)
    {
        // For simplicity, assuming that the entity has a property "Id" of type int
        // You might need reflection or a more sophisticated approach for generic repositories
        var entity = _context.Trips.FirstOrDefault(e => e.TripId == id);
        await SimulateAsyncDelay();
        return entity;
    }

    public async Task<IEnumerable<Trip>> GetAllTrips()
    {
        await SimulateAsyncDelay();
        return _context.Trips.AsEnumerable();
    }

    public async Task InsertTripAsync(Trip entity)
    {
        _context.Add(entity);
        await SimulateAsyncDelay();
    }

    public async Task UpdateTripAsync(Trip entity)
    {
        var existingEntity = _context.Trips.FirstOrDefault(e => e.TripId == entity.TripId);
        if (existingEntity != null)
        {
            _context.Remove(existingEntity);
            _context.Add(entity);
        }
        await SimulateAsyncDelay();
    }

    public async Task DeleteTripAsync(int id)
    {
        var entityToRemove = _context.Trips.FirstOrDefault(e => e.TripId == id);
        if (entityToRemove != null)
        {
            _context.Remove(entityToRemove);
        }
        await SimulateAsyncDelay();
    }
}