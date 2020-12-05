using System;
using System.Collections.Generic;
using System.Text;

namespace DUMPinternship_3_oop
{
    public class Event
    {
        public Event(string name, Event_Type eventType, DateTime startTime, DateTime endTime)
        {
            Name = name;
            EventType = eventType;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string Name { get; set; }
        public Event_Type EventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    
}
