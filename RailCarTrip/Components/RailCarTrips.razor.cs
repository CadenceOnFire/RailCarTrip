
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using RailCarTrip.Interface;
using RailCarTrip.Services;
using RailCarTrip.ViewModel;
using System;
using System.Linq;
using System.Linq.Expressions; 
public partial class RailCarTrips : ComponentBase
{
    protected List<EquipmentEvent> Rows = new();

    public TripEventsVModel tripModel { get; set; } = new();
    private IEquipmentEventImportService _service;

    protected override void OnInitialized()
    {
        // Example data (replace with API/service call)
        tripModel = new TripEventsVModel
        {
            TripId = 101,
            EquipmentEvents =
            {
                new EquipmentEventVModel
                {
                    EquipmentEventId = 1,
                    EquipmentId = 500,
                    EventCode = "LOAD",
                    EventType = "Loading",
                    EventTime = DateTime.UtcNow,
                    TimeZone = "UTC",
                    City = "Chicago",
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = "System"
                }
            } 
        };
    }
    public async Task HandleUpload(InputFileChangeEventArgs e)
    {
        var file = e.File;
        using var stream = file.OpenReadStream(10_000_000);
       var events = await _service.ImportAsync(file.Name);
    }

    public async void LoadFromExcel(InputFileChangeEventArgs e)
    {
        //add depency injection
        // add try catch exception
        var eqList = new List<EquipmentEvent>();
        // call ImportAsync


        // call API to save eqList to database
        // call Eventprocessor
      var model = _service.CreateTripsFromEvents(eqList);
    }
   
        // dependency inject RailCarAPI 

        // exctract from excel sheet

        // call service API to save Events

       // Refactor
       // move to EventProcessor class
       
    }

    // inital load
    // public async LoadTrips();

        // pass trip id to get events 
 