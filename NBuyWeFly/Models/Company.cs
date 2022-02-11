using NBuyWeFly.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyWeFly.Models
{
    public class Company
    {
        /// <summary>
        /// Şirket nesnesinin property'lerini tanımladık.
        /// </summary>
        public string Name { get; private set; }
        public string Code { get; private set; }

        private HashSet<Flight> flights = new HashSet<Flight>();

        public IReadOnlySet<Flight> Flights => flights;

        public Company(string name, string code)
        {
            this.Name = name;
            this.Code = code;

        }

        /// <summary>
        /// Company altına yeni bir flight bilgisi tanımlamamızı bu method ile kontrol ederiz. From, To, ArrivalDate, DepartureDate, FlightNumber önemli anlanlar olup eklemeden önce kontrol edilmelidir.
        /// Flight içerisindeki company alanı ise otomatik olarak burada set edilmelidir.
        /// // şirket için uçuş planlaması yapıldı
        /// </summary>
        /// <param name="flight"></param>
        public void AddNewFlight(Flight flight)
        {
            if(flight.From == null)
            {
                throw new Exception("Uçuş için kalkış yönü seçmelisiniz");
            }

            if(flight.To == null)
            {
                throw new Exception("Uçuş için varış yönü seçiniz");
            }

            if(flight.ArrivalDate == default(DateTime) || flight.DepartureDate == default(DateTime))
            {
                throw new Exception("Kalkış ve varış tarihini seçmelisiniz");
            }

            // sistemde daha önceden bir aynı flightNumber generate edilip edilmediğini kontrol edip, unique bir flightNumber oluşturulmasını garanti etmemiz gerekir. aşağıdaki kod satırı bunun algoritması için yazılmıştır.

            bool sameFlightNumber = false;

            do
            {
                flight.SetFlightNumber();
                sameFlightNumber = flights.Any(x => x.FlightNumber == flight.FlightNumber);
                
            }
            while (sameFlightNumber);

            // biz bu kod ile flight company bilgisini güvence altına almış olduk. Her şirket nesnesi kendi uçuşlarına company bilgisini gönderiyor.
            flight.SetCompany(this); // this keyword ile nesnein kendi referansını flight tanımlamış olduk.
            flights.Add(flight);
           
        }


    }
}
