
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RailCarTrip.Services;
using System;
using System.Linq;

public class ExcelViewerBase : ComponentBase
{
    protected List<EquipmentEvent> Rows = new();

    public async void LoadFromExcel(InputFileChangeEventArgs e)
    {
        //add depency injection
        // add try catch exception
        var eqList = new List<EquipmentEvent>();
        // call ImportAsync


        // call API to save eqList to database
        // call Eventprocessor
        CreateTripsFromEvents(eqList);
    }
   
        // dependency inject RailCarAPI 

        // exctract from excel sheet

        // call service API to save Events

       // Refactor
       // move to EventProcessor class
        public void CreateTripsFromEvents(List<EquipmentEvent> events)
        {
            // add try

            var trips = new List<Trip>();
            // get trips from RailCarAPI

            // calculate timezone based on citylocal
            // call API to get city timezone information by cityid
            //// event time to be calucated by timzeone based on city location


            var orderedEvts = events.OrderBy(e => e.EventTime);
            var startEvents = orderedEvts.Where(e => e.EventCode == "W");
            var endEvents = orderedEvts.Where(e => e.EventCode == "Z");

            // process event data and generate trip
            foreach (var startEvent in startEvents)
            {
                var trip = new Trip();
                trip.OriginCityId = startEvent.CityId;
                trip.StartUtc = startEvent.EventTime;

                var endEvt = endEvents.Where(e => e.EventTime > startEvent.EventTime && e.EquipmentId == startEvent.EquipmentId)
                    .OrderBy(e => e.EventTime).FirstOrDefault();


                if (endEvt != null)
                {
                    var eventsPerTrip = orderedEvts.Where(e => e.EventTime >= startEvent.EventTime && e.EventTime <= endEvt.EventTime);

                    var eqEvent = new EquipmentEvent();

                    trip.DestinationCityId = endEvt.CityId;
                    trip.EndUtc = endEvt.EventTime;
                }

                trips.Add(trip);
            }
            // call API to save trips

            // add catch exception
            //return trips;
        }

    // inital load
   // public async LoadTrips();
    
    // pass trip id to get events 


    }
 