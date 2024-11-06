using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_alapok
{
    internal class GroundControl
    {
        public List<Flight> AllFlights = new List<Flight>();
        public void AddFlight(Flight flightToAdd)
        {
            AllFlights.Add(flightToAdd);
        }
        private int AverageDelay()
        {
            return (int)Math.Round(AllFlights.Where(x => !x.Status.Equals(FlightStatus.Canceled)).Average(x => x.DelayInMinutes), 0);
        }
        public void DisplayFlightData()
        {
            foreach (Flight item in AllFlights)
            {
                Console.WriteLine(item.AllData());
            }
            Console.WriteLine($"The average delay is {AverageDelay()} minutes.");
        }
    }
}
