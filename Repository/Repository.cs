using Microsoft.EntityFrameworkCore;
using Repository.Interface; 
public class RailCartRepository<T> : IRepository<T> where T : class
{
    private DbContext  _dbContext;

    // Simulate a delay for async operations
    private Task SimulateAsyncDelay()
    {
        return Task.Delay(100); // 100ms delay for async simulation
    }

    public async Task<T> GetByIdAsync(int id)
    {
        // For simplicity, assuming that the entity has a property "Id" of type int
        // You might need reflection or a more sophisticated approach for generic repositories
        var entity = _dbContext.FirstOrDefault(e => (e as dynamic).Id == id);
        await SimulateAsyncDelay();
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        await SimulateAsyncDelay();
        return _dbContext.AsEnumerable();
    }

    public async Task InsertAsync(T entity)
    {
        _dbContext.Add(entity);
        await SimulateAsyncDelay();
    }

    public async Task UpdateAsync(T entity)
    {
        var existingEntity = _dbContext.FirstOrDefault(e => (e as dynamic).Id == (entity as dynamic).Id);
        if (existingEntity != null)
        {
            _dbContext.Remove(existingEntity);
            _dbContext.Add(entity);
        }
        await SimulateAsyncDelay();
    }

    public async Task DeleteAsync(int id)
    {
        var entityToRemove = _dbContext.FirstOrDefault(e => (e as dynamic).Id == id);
        if (entityToRemove != null)
        {
            _dbContext.Remove(entityToRemove);
        }
        await SimulateAsyncDelay();
    }
}