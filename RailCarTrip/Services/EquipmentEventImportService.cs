using CsvHelper;
using CsvHelper.Configuration;
using IronXL;
using RailCarAPI;
using RailCarTrip.Interface;
using RailCarTrip.ViewModel;
using System.Globalization;  
 
public class EquipmentEventImportService : IEquipmentEventImportService
{
    public async Task<List<EquipmentEvent>> ImportAsync(string fileName)
    {
        return  ReadExcel(fileName);
    }
     

    private List<EquipmentEvent> ReadExcel(string filenName)
    {
        var eqList = new List<EquipmentEvent>();
        WorkBook workBook = WorkBook.Load(filenName);//
        WorkSheet workSheet = workBook.WorkSheets.First();


        foreach (var row in workSheet.Rows)
        {
            var eq = new EquipmentEvent();

            //parse worksheet and ini eq
            //eq.EquipmentId = int.Parse(row.Cells[row, 1].Text),
            //eq.CityId = worksheet.Cells[row, 2].Text;
            //eq.EventTime = workSheet.Cells[row, 3].Text;
            //eq.CreatedDate = DateTime.UtcNow;
            eqList.Add(eq);
        }
        return eqList;
    }

    // ProcessTripsFromEventsAsync

    public List<TripEventsVModel> CreateTripsFromEvents(List<EquipmentEvent> events)
    {

        var trips = new List<Trip>();
        // get trips from RailCarAPI

        // calculate timezone based on citylocal
        // call API to get city timezone information by cityid
        //// event time to be calucated by timzeone based on city location


        var orderedEvts = events.OrderBy(e => e.EventTime);
        var startEvents = orderedEvts.Where(e => e.EventCode == "W");
        var endEvents = orderedEvts.Where(e => e.EventCode == "Z");
        var tripEvents = new List<TripEventsVModel>();
        try
        {
            // process event data and generate trip
            foreach (var startEvent in startEvents)
            {
                var trip = new Trip();
                trip.OriginCityId = startEvent.CityId;
                trip.StartUtc = startEvent.EventTime;

                var endEvt = endEvents.Where(e => e.EventTime > startEvent.EventTime && e.EquipmentId == startEvent.EquipmentId)
                    .OrderBy(e => e.EventTime).FirstOrDefault();

                var tripEvent = new TripEventsVModel();
                if (endEvt != null)
                {
                    var tripEve = orderedEvts.Where(e => e.EventTime >= startEvent.EventTime && e.EventTime <= endEvt.EventTime);
                    // convert to view model - refactor move to mapper later
                    tripEvent.EquipmentEvents = tripEve
                        .Select(s => new EquipmentEventVModel
                        { CityId = s.CityId, EventCode = s.EventCode, EquipmentEventId = s.EquipmentEventId, EventTime = s.EventTime }).ToList();

                    var eqEvent = new EquipmentEvent();

                    trip.DestinationCityId = endEvt.CityId;
                    trip.EndUtc = endEvt.EventTime;
                }
                tripEvents.Add(tripEvent);
                trips.Add(trip);
            }
        }
        // call API to save trips
        catch (Exception e)
        {
            //_logeger
        }
        return tripEvents;
    }
     
}