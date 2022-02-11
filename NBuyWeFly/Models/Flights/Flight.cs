using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyWeFly.Models.Flights
{
    /// <summary>
    /// uçuş sınıfımız
    /// </summary>
    public class Flight
    {
        public Airport From { get; private set; }
        public Airport To { get; private set; }

        public DateTime ArrivalDate { get; private set; }

        public DateTime DepartureDate { get; private set; }

        public Company Company { get; private set; }

        //uçuş numarasıı
        public string FlightNumber { get; private set; }



        public Flight(Airport from, Airport to,  DateTime departureDate, DateTime arrivalDate)
        {
            From = from;
            To = to;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
        }

        /// <summary>
        /// Unique bir Flight Number oluşturur.
        /// </summary>
        public void SetFlightNumber()
        {
            var random = new Random();
            int flightNumber = random.Next(1000, 10000);

            this.FlightNumber = $"{Company.Code}-{flightNumber}"; // THY-1760
        }

        /// <summary>
        /// Her şirket kendine ait uçuşları bu methodu kullanarak yönetiyor.
        /// </summary>
        /// <param name="company"></param>
        public void SetCompany(Company company)
        {
            this.Company = company;
        }





    }
}
