using System;
using System.Collections.Generic;
using System.Text;

namespace RailCarAPI.Interface
{    public interface ITripRepository<T>
    {
        Task<T> GetTripByIdAsync(int id);
        Task<IEnumerable<T>> GetAllTrips();
        Task InsertTripAsync(T entity);
        Task UpdateTripAsync(T entity);
        Task DeleteTripAsync(int id);
    }
}
