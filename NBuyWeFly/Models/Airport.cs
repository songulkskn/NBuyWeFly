using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyWeFly.Models
{
    /// <summary>
    /// Uçuş bilgisi için From To Hava limanı seçimi için kullanırız
    /// </summary>
    public class Airport
    {
     
        public string Name { get; private set; }
        public string ShortCode { get; private set; }
        public string CityName { get; private set; }
        public Airport(string name, string shortCode, string cityName)
        {
            Name = name;
            ShortCode = shortCode;
            CityName = cityName;
        }
    }
}
