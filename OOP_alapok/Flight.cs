using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP_alapok.FlightStatus;

namespace OOP_alapok
{
    internal class Flight
    {
        int _id;
        public int Id => _id;

        string _dest;
        public string Dest => _dest;

        DateTime _plannedLeave;
        public DateTime PlannedLeave => _plannedLeave;

        int _delayInMinutes;
        public int DelayInMinutes => _delayInMinutes;

        FlightStatus _status;
        public FlightStatus Status => _status;
        public void Cancel()
        {
            _status = FlightStatus.Canceled;
        }
        public void Delay(int seconds)
        {
            _delayInMinutes = seconds;
        }
        public void UpdateStatus(FlightStatus newStatus)
        {
            _status = newStatus;
        }
        public void UpdateStatus()
        {
            if (DelayInMinutes.Equals(0))
            {
                _status = FlightStatus.Scheduled;
            }
            else
            {
                _status = FlightStatus.Delayed;
            }
        }
        public string AllData()
        {
            if (_status.Equals(FlightStatus.Canceled))
                return $"Flight {Id} is canceled.";

            if (_status.Equals(FlightStatus.Delayed))
                return $"Flight {Id} is delayed by {DelayInMinutes} minutes. ({EstimatedDeparture():yyyy. MM. dd. HH:mm:ss})";
            else//Ha schedule-d
                return $"Flight {Id} is on time. ({EstimatedDeparture():yyyy. MM. dd. HH:mm:ss})";
        }
        public DateTime EstimatedDeparture()
        {
            return _plannedLeave.AddMinutes(DelayInMinutes);
        } 
        public Flight(int FlightId, string Destination, DateTime PlannedLeave, int DelayedSeconds)
        {
            _id = FlightId;
            _dest = Destination;
            _plannedLeave = PlannedLeave;
            _delayInMinutes = DelayedSeconds;
        }
        public Flight(int FlightId, string Destination, DateTime PlannedLeave)
        {
            _id = FlightId;
            _dest = Destination;
            _plannedLeave = PlannedLeave;
            _delayInMinutes = 0;
        }
    }
}
