using System;
using System.Collections.Generic;
using System.Text;

namespace DUMPinternship_3_oop
{
    public class Person
    {
        public Person(string firstName, string lastName, string oib, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            OIB = oib;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public string PhoneNumber { get; set; }
    }
}
