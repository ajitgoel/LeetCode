using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Amazon
{
  public struct Crossing
  {
    public long Time { get; set; }
    public Location Location { get; set; }
  }
  /*https://stackoverflow.com/questions/28068123/double-or-decimal-for-latitude-longitude-values-in-c-sharp
   * A double has up to 15 decimal digits of precision. So, lets assume three of those digits are going to be on the 
   * left of the decimal point for lat/long values (max of 180deg). This leaves 12 digits of precision on the right. 
   * Since a degree of lat/long is ~111km, 5 of those 12 digits would give us precision to the meter. 
   * 3 more digits would give us precision to the millimeter. The remaining 4 digits would get us precision to 
   * around 100 nanometers. Since double will win from the perspective of performance and memory, 
   * I see no reason to even consider using decimal.
   
    float=> 32 bites=> 4 bytes
    double=>64 bites=> 8 bytes
    double.Epsilon=> Represents the smallest positive System.Double value that is greater than zero.
   */
  public struct Location
  {
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public static bool operator ==(Location b1, Location b2)
    {
      if ((object)b1 == null)
      {  
        return (object)b2 == null;
      }
      return b1.Equals(b2);
    }
    public static bool operator !=(Location b1, Location b2)
    {
      return !(b1 == b2);
    }
    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }
      var b2 = (Location)obj;
      return (System.Math.Abs(Longitude - b2.Longitude) < double.Epsilon && System.Math.Abs(Latitude - b2.Latitude) < double.Epsilon);
    }
    public override int GetHashCode()
    {
      return Latitude.GetHashCode() ^ Latitude.GetHashCode();
    }
  }
  public class NoOfTimesIntersectionWasCrossedBetweenStartAndEndTimes
  {
    public int CalculateFrequency(long startTime, long endTime, Location location, List<Crossing> crossings)
    {
      return crossings.Count(x => x.Time >= startTime && x.Time <= endTime && x.Location==location); 
    }    
    [Fact]
    public void Test2()
    {
      var crossings = new List<Crossing>() 
      { 
        new Crossing() { Location = new Location() { Latitude = 11, Longitude = 20 }, Time = 123 },
        new Crossing() { Location = new Location() { Latitude = 21, Longitude = 30 }, Time = 123 },
        new Crossing() { Location = new Location() { Latitude = 31, Longitude = 40 }, Time = 123 },
        new Crossing() { Location = new Location() { Latitude = 11, Longitude = 20 }, Time = 124 },
      };
      CalculateFrequency(123, 124, new Location() { Latitude = 11, Longitude = 20 }, crossings).Should().Be(2);
    }
  }
}
