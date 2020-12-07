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
            var result = 0;
                do
                {
                Console.WriteLine("Odaberite akciju:");
                Console.WriteLine("1 - dodavanje eventa");
                Console.WriteLine("2 - brisanje eventa");
                Console.WriteLine("3 - edit Eventa");
                Console.WriteLine("4 - dodavanje osobe na event");
                Console.WriteLine("5 - uklanjane osobe sa eventa");
                Console.WriteLine("6 - Ispis detalja eventa");
                Console.WriteLine("7 - prekid rada");
                var action = Console.ReadLine();

                bool parseSuccess = int.TryParse(action, out result);
                while (!parseSuccess)
                {
                    Console.WriteLine("unijeli ste neispravnu vrijednost unesite ponovno:");
                    action = Console.ReadLine();

                    parseSuccess = int.TryParse(action, out result);
                }


                switch (result)
                {
                    case 1:
                        Addingevent(eventDic);
                        break;
                    case 2:
                        DeleteEvent(eventDic);
                        break;
                    case 3:
                        EditEvent(eventDic);
                        break;
                    case 7:
                        break;
                }
                } while (result != 7);
           


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

           if(EventName(myDic,name) && EndBeforeStart(newEvent) && Overlap(myDic,newEvent))
           {
                myDic.Add(newEvent, people);
                Console.WriteLine("event je uspjesno dodan!");
           }
           else
           {
                Console.WriteLine("event nije moguce dodati.");
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

       public static void EditEvent(Dictionary<Event,List<Person>> eventDic)
       {
            Console.WriteLine("upisite ime eventa kojeg zelite editirati:");
            var name = Console.ReadLine();

            if(!EventName(eventDic,name))
            {
                Console.WriteLine("upisite sto zelite editirati: 1-ime eventa, 2-vrijeme pocetka,3-vrijeme zavrsetka");
                var edit = int.Parse(Console.ReadLine());



                switch (edit)
                {
                    case 1:
                        Console.WriteLine("upisite novo ime eventa:");
                        var newName = Console.ReadLine();

                        if(EventName(eventDic,newName))
                        {
                            foreach (var pair in eventDic)
                            {
                                if (pair.Key.Name == name)
                                {
                                    pair.Key.Name = newName;
                                    Console.WriteLine("ime eventa je uspjesno promijenjeno!");
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("vec postoji event s ovim imenom.");
                            Menu(eventDic);
                        }
                        break;
                    case 2:
                        Console.WriteLine("upisite novi pocetak eventa:");
                        var newStart = DateTime.Parse(Console.ReadLine());

                        foreach(var pair in eventDic) 
                        { 
                            if(pair.Key.Name==name)
                            {

                                pair.Key.StartTime = newStart;
                                Console.WriteLine("uspjesno je promijenjeno vrijeme pocetka.");
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("upisite novi zavrsetak eventa:");
                        var newEnd = DateTime.Parse(Console.ReadLine());

                        foreach (var pair in eventDic)
                        {
                            if (pair.Key.Name == name)
                            {
                                pair.Key.StartTime = newEnd;
                                Console.WriteLine("uspjesno je promijenjeno vrijeme zavrsetka.");
                            }
                        }
                        break;
                }

            }
            else
            {
                Console.WriteLine("Event s ovim imenom ne postoji!");
                Menu(eventDic);
            }
       }
       
        public static void AddingPerson(Dictionary<Event,List<Person>> eventDic)
        {
            Console.WriteLine("upisite ime eventa na koji zelite dodati osobu:");
            var name = Console.ReadLine();

            Console.WriteLine("upisite ime osobe koju zelite dodati:");
            var personName = Console.ReadLine();

            Console.WriteLine("upisite prezime osobe koju zelite dodati:");
            var personLastName = Console.ReadLine();

            Console.WriteLine("unesite oib osobe koju zelite dodati:");
            var OIB = Console.ReadLine();

            Console.WriteLine("unesite broj telefona osobe koju zelite dodati:");
            var phoneNumber = Console.ReadLine();

            var person = new Person(name, personLastName, OIB, phoneNumber);

            if(!SameOIB(eventDic,person))
            {
                Console.WriteLine("osoba koju ste upisali je vec na popisu za taj event.");
            }
            else
            {
                foreach(var pair in eventDic)
                {
                    if(pair.Key.Name==name)
                    {
                        pair.Value.Add(person);
                        Console.WriteLine("osoba je uspjesno dodana!");
                    }
                }
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

            var firstEvent = new Event("coffee with a friend", Event_Type.coffee, new DateTime(2020, 3, 1, 7, 0, 0), new DateTime(2020, 3, 1, 9, 0, 0));
            var secondEvent = new Event("madonnas concert", Event_Type.concert, new DateTime(2020, 3, 2, 10, 0, 0), new DateTime(2020, 3, 2, 11, 0, 0));
            var thirdEvent = new Event("math", Event_Type.studySession, new DateTime(2020, 3, 3, 7, 0, 0), new DateTime(2020, 3, 3, 11, 0, 0));
            var fourthEvent = new Event("english", Event_Type.lecture, new DateTime(2020, 3, 4, 9, 0, 0), new DateTime(2020, 3, 4, 12, 0, 0));

            Dictionary<Event, List<Person>> eventDic = new Dictionary<Event, List<Person>>()
            {
                {firstEvent,new List<Person>{firstPerson,secondPerson} },
                {secondEvent,new List<Person>{thirdPerson,fourthPerson} },
                {thirdEvent, new List<Person> {fifthPerson,sixthPerson } },
                {fourthEvent, new List<Person> {seventhPerson, eighthPerson } }
            };

            Menu(eventDic);
        }
    }
       
}

