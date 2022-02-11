using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyWeFly.Models.Flights
{
    public class FlightTypePrice
    {
        //uçuş bilgisi
        public string Type { get; private set; }
        public string Currency { get; private set; }

        public decimal ListPrice { get; private set; }

        private FlightTypePrice(string type, string currency, decimal listPrice)
        {
            Type = type;
            Currency = currency;
            ListPrice = listPrice;
        }

     
        public static FlightTypePrice CreateInstance(string type, string currency, decimal listPrice)
        {
            return new FlightTypePrice(type,  currency,  listPrice);
        }

        
    }
}
