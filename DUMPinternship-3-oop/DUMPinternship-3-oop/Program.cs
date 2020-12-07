using System;
using System.Collections.Generic;
namespace DUMPinternship_3_oop
{
    class Program
    {
        public static bool EventName(Dictionary<Event, List<Person>> eventDic, string name)
        {

            foreach (var pair in eventDic)
            {
                var temp = pair.Key;
                if (temp.Name == name)
                {
                    return false;
                }

            }
            return true;
        }
        public static bool EndBeforeStart(Event newEvent)
        {

            if (newEvent.StartTime > newEvent.EndTime)
                return false;
            else
                return true;
        }
        public static bool Overlap(Dictionary<Event, List<Person>> eventDic, Event newEvent)
        {
            foreach (var pair in eventDic)
            {
                if (pair.Key.StartTime == newEvent.StartTime)
                {
                    if (pair.Key.EndTime == newEvent.EndTime)
                        return false;
                    else
                        return true;
                }
            }
            return true;
        }
        public static bool SameOIB(Dictionary<Event, List<Person>> eventDic, Person newPerson)
        {

            foreach (var pair in eventDic)
            {
                foreach (var person in pair.Value)
                {
                    if (newPerson.OIB == person.OIB)
                        return false;
                }
            }
            return true;
        }
        public static void Menu(Dictionary<Event, List<Person>> eventDic)
        {

        }
        public static void Addingevent(Dictionary<Event,List<Person>> myDic)
        {
            Event newEvent = null;
            var people = new List<Person>();

            Console.WriteLine("upisite ime eventa kojeg zelite dodati:");
            var name = Console.ReadLine();

            Console.WriteLine("upisite tip eventa kojeg zelite dodati(0 za coffee, 1 za lecture, 2 za lecture ili 3 za studysession:");
            var eventType = Console.ReadLine();

            bool parseSuccess = int.TryParse(eventType, out int result);
            while(!parseSuccess)
            {
                Console.WriteLine("unijeli ste neispravnu vrijednost unesite ponovno:");
                 eventType = Console.ReadLine();

                parseSuccess = int.TryParse(eventType, out result);
            }

            Console.WriteLine("upisite pocetak eventa kojeg zelite dodati:");
            var startTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("upisite zavrsetak eventa kojeg zelite dodati:");
            var endTime = DateTime.Parse(Console.ReadLine());

           if(result == 0)
           {
                 newEvent = new Event(name, Event_Type.coffee, startTime, endTime);
           }
           else if(result==1)
           {
                 newEvent = new Event(name, Event_Type.lecture, startTime, endTime);
           }
           else if(result==2)
           {
                newEvent = new Event(name, Event_Type.concert, startTime, endTime);
           }

           if(EventName(myDic,name))
           {
                myDic.Add(newEvent, people);
                Console.WriteLine("event je uspjesno dodan!");
           }
           else
           {
                Console.WriteLine("vec postoji event s tim imenom!");
                Menu(myDic);
           }
        }

        public static void DeleteEvent(Dictionary<Event, List<Person>> eventDic)
        {
            bool succesfullRemove = true;

            Console.WriteLine("upisite ime eventa kojeg zelite izbrisati:");
            var name = Console.ReadLine();

            foreach (var pair in eventDic)
            {
                if (pair.Key.Name == name)
                {
                    succesfullRemove = eventDic.Remove(pair.Key);
                    break;
                }
            }

            if (succesfullRemove)
            {
                Console.WriteLine("event je uspjesno izbrisan.");
            }
            else
            {
                Console.WriteLine("ne postoji envent s tim imenom!");
                Menu(eventDic);
            }
           
        }

       

        static void Main()
        {
            var firstPerson = new Person("Lana", "Bevc", "12345678911", "0991111111");
            var secondPerson = new Person("Laura", "Bevc", "23456789222", "0992222222");
            var thirdPerson = new Person("Harry", "Styles", "84567893333", "0993333333");
            var fourthPerson = new Person("Spock", "Vulcan", "24567893333", "0993333334");
            var fifthPerson = new Person("James", "Kirk", "64567893333", "0993333335");
            var sixthPerson = new Person("Leonard", "McCoy", "74567893333", "0993333336");
            var seventhPerson = new Person("Scott", "Montgomery", "94567893333", "0993333337");
            var eighthPerson = new Person("Christine", "Chapel", "14567893333", "0993333338");

            var firstEvent = new Event("Coffee with a friend", Event_Type.coffee, new DateTime(2020, 3, 1, 7, 0, 0), new DateTime(2020, 3, 1, 9, 0, 0));
            var secondEvent = new Event("Madonnas concert", Event_Type.concert, new DateTime(2020, 3, 2, 10, 0, 0), new DateTime(2020, 3, 2, 11, 0, 0));
            var thirdEvent = new Event("Math", Event_Type.studySession, new DateTime(2020, 3, 3, 7, 0, 0), new DateTime(2020, 3, 3, 11, 0, 0));
            var fourthEvent = new Event("English", Event_Type.lecture, new DateTime(2020, 3, 4, 9, 0, 0), new DateTime(2020, 3, 4, 12, 0, 0));

            Dictionary<Event, List<Person>> eventDic = new Dictionary<Event, List<Person>>()
            {
                {firstEvent,new List<Person>{firstPerson,secondPerson} },
                {secondEvent,new List<Person>{thirdPerson,fourthPerson} },
                {thirdEvent, new List<Person> {fifthPerson,sixthPerson } },
                {fourthEvent, new List<Person> {seventhPerson, eighthPerson } }
            };

        }
    }
       
}

