using CsvHelper;
using CsvHelper.Configuration;
using IronXL;
using RailCarAPI;
using RailCarTrip.Interface;
using System.Globalization;  
 
public class EquipmentEventImportService : IEquipmentEventImportService
{
    public async Task<List<EquipmentEvent>> ImportAsync(string fileName)
    {
        return  ReadExcel(fileName);
    }


    private async Task<List<EquipmentEvent>> ReadCsv(Stream stream)
    {
        using var reader = new StreamReader(stream);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        });


        return csv.GetRecords<EquipmentEvent>().ToList();
        //        //await _railCarApi.AddRangeAsync(records);
    }


    private List<EquipmentEvent> ReadExcel(string filenName)
    {
        
        WorkBook workBook = WorkBook.Load("sample.xlsx");
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

    }

    // ProcessTripsFromEventsAsync


}