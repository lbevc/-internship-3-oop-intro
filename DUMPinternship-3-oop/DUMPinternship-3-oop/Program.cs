using System;
using System.Collections.Generic;
namespace DUMPinternship_3_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPerson = new Person("Lana", "Bevc", "12345678911", "0991111111");
            var secondPerson = new Person("Laura", "Bevc", "23456789222", "0992222222");
            var thirdPerson = new Person("Harry", "Styles", "84567893333", "0993333333");
            var fourthPerson = new Person("Spock", "Vulcan", "24567893333", "0993333334");
            var fifthPerson = new Person("James", "Kirk", "64567893333", "0993333335");
            var sixthPerson = new Person("Leonard", "McCoy", "74567893333", "0993333336");
            var seventhPerson = new Person("Scott", "Montgomery", "94567893333", "0993333337");
            var eighthPerson = new Person("Christine", "Chapel", "14567893333", "0993333338");

            var firstEvent = new Event("Coffee with a friend", Event_Type.Coffee,new DateTime(2020,3,1,7,0,0),new DateTime(2020,3,1,9,0,0));
            var secondEvent = new Event("Madonnas concert", Event_Type.Concert, new DateTime(2020, 3, 2, 10, 0, 0), new DateTime(2020, 3, 2, 11, 0, 0));
            var thirdEvent = new Event("Math", Event_Type.StudySession, new DateTime(2020, 3, 3, 7, 0, 0), new DateTime(2020, 3, 3, 11, 0, 0));
            var fourthEvent = new Event("English", Event_Type.Lecture, new DateTime(2020, 3, 4, 9, 0, 0), new DateTime(2020, 3, 4, 12, 0, 0));

            Dictionary<Event, List<Person>> myDic = new Dictionary<Event, List<Person>>()
            {
                {firstEvent,new List<Person>{firstPerson,secondPerson} },
                {secondEvent,new List<Person>{thirdPerson,fourthPerson} },
                {thirdEvent, new List<Person> {fifthPerson,sixthPerson } },
                {fourthEvent, new List<Person> {seventhPerson, eighthPerson } }
            };

        }
    }
}
