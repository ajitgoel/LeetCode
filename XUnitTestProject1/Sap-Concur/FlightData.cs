using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SAP.Concur
{
  public class FlightData
  {
    //used IEnumerable to return the file data so the data is streamed to the client application (instead of being generated in memory and returned to client application eg: using lists).
    public IEnumerable<Flight> ParseFile()
    {
      //Used File.ReadLines to read the file line one by one since it is more performant compared to reading all the file lines in memory. 
      var lines = File.ReadLines("Sap-Concur\\flightdata.txt");
      foreach (var line in lines)
      {
        var remainingLinelength = line.Length - 11;
        var regex = "(?<linenumber>.{2})(?<carrier_operatingCarrier_FlightNumber>.{9})(?<remainingLine>.{" + remainingLinelength + "})";
        var matchCollection = Regex.Matches(line, regex);
        _ = int.TryParse(matchCollection[0].Groups["linenumber"].ToString(), out int lineNumber);
        var carrier_operatingCarrier_FlightNumber = matchCollection[0].Groups["carrier_operatingCarrier_FlightNumber"].ToString()?.Trim();
        var remainingLine = matchCollection[0].Groups["remainingLine"].ToString().Trim();
        var remainingLine_Splits = remainingLine?.Split(new char[] { ' ' });
        if (remainingLine_Splits?.Last() == "*" || remainingLine_Splits?.Last() == "/E" && remainingLine_Splits?.Last() == "/")
        {
          remainingLine_Splits = remainingLine_Splits?.SkipLast(1).ToArray();
        }
        var flight = new Flight();
        var carrier = carrier_operatingCarrier_FlightNumber?.Substring(0, 2)?.Trim();
        var operatingCarrier = "";
        string? flightNumber;
        var operatingCarrier_FlightNumber = carrier_operatingCarrier_FlightNumber?.Substring(2);
        if (operatingCarrier_FlightNumber != null && operatingCarrier_FlightNumber.StartsWith(':'))
        {
          operatingCarrier_FlightNumber = operatingCarrier_FlightNumber.Substring(1);
          operatingCarrier = operatingCarrier_FlightNumber.Substring(0, 2)?.Trim();
          flightNumber = operatingCarrier_FlightNumber?.Substring(2)?.Trim();
        }
        else
        {
          flightNumber = operatingCarrier_FlightNumber?.Trim();
        }
        #region classes
        var classes = "";
        var index = 0;
        for (var counter = 0; counter < remainingLine_Splits?.Length; counter++)
        {
          var counterline = remainingLine_Splits[counter];
          if (counterline.Length == 2)
          {
            classes += counterline?.Substring(0, 1);
            index++;
          }
          else
          {
            break;
          }
        }
        #endregion 

        #region departureAirport, arrivalAirport
        var departureAirport = "";
        var arrivalAirport = "";
        for (var counter = index; counter < remainingLine_Splits?.Length; counter++)
        {
          var counterline = remainingLine_Splits[counter];
          if (counterline.Length == 0)
          {
            index++;
          }
          else if (counterline.StartsWith('/') == false && counterline.Length == 3)
          {
            departureAirport = counterline;
            index++;
            break;
          }
          else if (counterline.StartsWith('/') == true && counterline.Length == 4)
          {
            departureAirport = counterline.Substring(1);
            index++;
            break;
          }
          else if (counterline.Length == 6)
          {
            departureAirport = counterline.Substring(0, 3);
            arrivalAirport = counterline.Substring(3, 3);
            index++;
            break;
          }
          else
          {
            index++;
          }
        }
        #endregion

        #region arrivalAirport
        if (string.IsNullOrEmpty(arrivalAirport))
        {
          for (var counter = index; counter < remainingLine_Splits?.Length; counter++)
          {
            var counterline = remainingLine_Splits[counter];
            if (counterline.Length == 3)
            {
              arrivalAirport = counterline;
              index++;
              break;
            }
            else
            {
              index++;
            }
          }
        }
        #endregion

        #region departureTime
        var departureTime = "";
        for (var counter = index; counter < remainingLine_Splits?.Length; counter++)
        {
          var counterline = remainingLine_Splits[counter];
          if (counterline.Length >= 4)
          {
            departureTime = counterline.Substring(0, 4);
            index++;
            break;
          }
          else
          {
            index++;
          }
        }
        #endregion

        #region arrivalTime, arrivalTimeShift, equipment
        var arrivalTime = "";
        var arrivalTimeShift = "";
        var equipment = "";
        var string1 = "E0.";
        var string2 = "E0/";

        for (var counter = index; counter < remainingLine_Splits?.Length; counter++)
        {
          var counterline = remainingLine_Splits[counter];
          if (counterline.Length > 4)
          {
            arrivalTime = counterline.Substring(0, 4);
            var dotindex = counterline.IndexOf(string1);
            var slashindex = counterline.IndexOf(string2);
            var indextouse = dotindex >= 0 ? dotindex + string1.Length :
              (slashindex >= 0 ? slashindex + string2.Length : -1);
            arrivalTimeShift = counterline.Substring(4, counterline.Length - indextouse - 1);
            equipment = counterline.Substring(indextouse);
            index++;
            break;
          }
          else if (counterline.Length == 4)
          {
            arrivalTime = counterline.Substring(0, 4);
            index++;
            break;
          }
          else
          {
            index++;
          }
        }
        #endregion

        #region arrivalTime, arrivalTimeShift, equipment
        if (string.IsNullOrEmpty(arrivalTimeShift) && string.IsNullOrEmpty(equipment))
        {
          for (var counter = index; counter < remainingLine_Splits?.Length; counter++)
          {
            var counterline = remainingLine_Splits[counter];
            var dotindex = counterline.IndexOf(string1);
            var slashindex = counterline.IndexOf(string2);
            if (dotindex >= 0 || slashindex >= 0)
            {
              var indextouse = dotindex >= 0 ? dotindex + string1.Length :
                (slashindex >= 0 ? slashindex + string2.Length : -1);
              equipment = counterline.Substring(indextouse);
              index++;
              break;
            }
            else
            {
              index++;
            }
          }
        }
        #endregion
        #region ontime
        var ontime = "";
        for (var counter = index; counter < remainingLine_Splits?.Length - 1; counter++)
        {
          var counterline = remainingLine_Splits[counter];
          if (counterline != null && (counterline == "N" || counterline == "Y"))
          {
            ontime = counterline;
            index++;
            break;
          }
          else
          {
            index++;
          }
        }
        #endregion

        var duration = remainingLine_Splits?.Last();

        flight.LineNumber = lineNumber;
        flight.Carrier = carrier;
        flight.OperatingCarrier = operatingCarrier;
        flight.FlightNumber = flightNumber;
        flight.Classes = classes;
        flight.DepartureAirport = departureAirport;
        flight.ArrivalAirport = arrivalAirport;
        flight.DepartureTime = departureTime;
        flight.ArrivalTime = arrivalTime;
        flight.ArrivalTimeShift = arrivalTimeShift;
        flight.Equipment = equipment;
        flight.Ontime = ontime;
        flight.Duration = duration;
        //used yield keyword, so the client application can process the information without waiting for the complete enumerator to complete the task.
        yield return flight;
      }
    }
  }
  public class Flight
  {
    public int LineNumber { get; set; }
    public string? Carrier { get; set; }
    public string? OperatingCarrier { get; set; }
    public string? FlightNumber { get; set; }
    public string? Classes { get; set; }
    public string? DepartureAirport { get; set; }
    public string? ArrivalAirport { get; set; }
    public string? DepartureTime { get; set; }
    public string? ArrivalTime { get; set; }
    public string? ArrivalTimeShift { get; set; }
    public string? Equipment { get; set; }
    public string? Ontime { get; set; }
    public string? Duration { get; set; }
  }
}