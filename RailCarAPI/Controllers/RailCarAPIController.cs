
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using RailCarAPI.Interface;
using System.Globalization;

namespace RailCarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RailCarAPIController : ControllerBase
    {
        protected readonly ITripRepository<Trip>  _tripRepo;
        protected readonly IEquipmentEventRepository _euiprepo;

        public RailCarAPIController(ITripRepository<Trip> tripRepo, IEquipmentEventRepository  equipRepo )
        {
            _tripRepo = tripRepo;
            _euiprepo = equipRepo;
        }

        [HttpGet(Name = "GetRailCarTrips")]
        public async Task<IEnumerable<Trip>> GetAllTrips()
        {
            return await  _tripRepo.GetAllTrips();
        }
        [HttpGet(Name = "GetRailCarTripById")]
        public async Task<Trip> GetTripByID(int Id)
        {
            return await _tripRepo.GetTripByIdAsync(Id);
        }
        [HttpPost(Name = "GetEquipmentEvent")]
        public async Task<IActionResult> SaveEvents(IEnumerable<EquipmentEvent> events)
        {
             await _euiprepo.AddRangeAsync(events);
            return Ok("Import successful");

            //     public async Task ImportAsync(Stream fileStream)
            //{
            //    using var reader = new StreamReader(fileStream);
            //    using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            //    {
            //        HeaderValidated = null,
            //        MissingFieldFound = null
            //    });

            //    var records = csv.GetRecords<EquipmentEvent>().ToList();
            //    await _repository.AddRangeAsync(records);
            //}
        }
    }
}
