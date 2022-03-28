using Xunit;
using FluentAssertions;
using System.Linq;

namespace SAP.Concur.Tests
{
  public class UnitTest
  {
    [Fact]
    public void ParseFileTest_Line2()
    {
      var flights = new SAP.Concur.FlightData().ParseFile();
      #region flightLine2
      var flightLine2 = flights.ElementAt(1);
      flightLine2.LineNumber.Should().Be(2);
      flightLine2.Carrier.Should().Be("AA");
      flightLine2.OperatingCarrier.Should().Be("");
      flightLine2.FlightNumber.Should().Be("2421");
      flightLine2.Classes.Should().Be("FAYBMHK");
      flightLine2.DepartureAirport.Should().Be("DFW");
      flightLine2.ArrivalAirport.Should().Be("LAX");
      flightLine2.DepartureTime.Should().Be("1106");
      flightLine2.ArrivalTime.Should().Be("1215");
      flightLine2.ArrivalTimeShift.Should().Be("");
      flightLine2.Equipment.Should().Be("777");
      flightLine2.Ontime.Should().Be("");
      flightLine2.Duration.Should().Be("3:09");
      #endregion
    }
    [Fact]
    public void ParseFileTest_Line3()
    {
      var flights = new SAP.Concur.FlightData().ParseFile();
      #region flightLine3
      var flightLine3 = flights.ElementAt(2);
      flightLine3.LineNumber.Should().Be(3);
      flightLine3.Carrier.Should().Be("UA");
      flightLine3.OperatingCarrier.Should().Be("US");
      flightLine3.FlightNumber.Should().Be("6352");
      flightLine3.Classes.Should().Be("BMHK");
      flightLine3.DepartureAirport.Should().Be("DFW");
      flightLine3.ArrivalAirport.Should().Be("LAX");
      flightLine3.DepartureTime.Should().Be("1200");
      flightLine3.ArrivalTime.Should().Be("1448");
      flightLine3.ArrivalTimeShift.Should().Be("");
      flightLine3.Equipment.Should().Be("733");
      flightLine3.Ontime.Should().Be("");
      flightLine3.Duration.Should().Be("1:48");
      #endregion
    }

    [Fact]
    public void ParseFileTest_Line18()
    {
      var flights = new SAP.Concur.FlightData().ParseFile();
      # region flightLine18
      var flightLine18 = flights.ElementAt(17);
      flightLine18.LineNumber.Should().Be(18);
      flightLine18.Carrier.Should().Be("HP");
      flightLine18.OperatingCarrier.Should().Be("");
      flightLine18.FlightNumber.Should().Be("497");
      flightLine18.Classes.Should().Be("WBQL");
      flightLine18.DepartureAirport.Should().Be("DFW");
      flightLine18.ArrivalAirport.Should().Be("LAX");
      flightLine18.DepartureTime.Should().Be("1700");
      flightLine18.ArrivalTime.Should().Be("1943");
      flightLine18.ArrivalTimeShift.Should().Be("+1");
      flightLine18.Equipment.Should().Be("319");
      flightLine18.Ontime.Should().Be("N");
      flightLine18.Duration.Should().Be("1:43");
      #endregion
    }
  }
}