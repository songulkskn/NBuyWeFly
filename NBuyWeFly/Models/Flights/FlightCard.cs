using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyWeFly.Models.Flights
{
    // ubiquitous language
    public class FlightCard
    {
        /// <summary>
        /// Uçuş kartında göstereceğimiz kalkış saati
        /// </summary>
        public string DepartureTime { get; private set; }

        /// <summary>
        /// Uçuş kartında göstereceğimiz varış saati
        /// </summary>
        public string ArrivalTime { get; private set; }

        /// <summary>
        /// Uçuş kartındaki uçuşun aktarmalı olup olmadığı bilgisi
        /// </summary>
        public bool Indirect { get; private set; }

        private List<FlightTypePrice> flightTypePrices = new List<FlightTypePrice>();

        /// <summary>
        /// Uçuş kartındaki gösterilecek olan Bussines, Economy fiyat bilgisi
        /// </summary>
        public IReadOnlyList<FlightTypePrice> FlightTypePrices => flightTypePrices;

        private HashSet<Flight> flights = new HashSet<Flight>();

        /// <summary>
        /// Uçuş kartındaki uçuşların bilgileri. Aktarmalı ise birden fazla olabilir.
        /// </summary>
        public IReadOnlySet<Flight> Flights => flights;

        public FlightCard(bool indirect)
        {
            this.Indirect = indirect;
        }

        /// <summary>
        /// Uçuş kartına uçuş bilgisi tanımlarken kontrolden geçmesini sağlar
        /// Aktarmalı ve aktarmasız uçuşların sisteme doğru bir şekilde tanımlanmasını garanti eder. private olarak işaretlenmesinin sebebi bu işin sınıf içerisinde yapılması gerekliliğidir. 
        /// </summary>
        /// <param name="flight">Sisteme girilecek yeni fligt bilgisinin kontrolü için ekledik</param>
        private void CheckFlightRequest(Flight flight)
        {
            // Aktarmalıysa en fazla 3 adet aktarma olabilir kontrolü
            if (Indirect && flights.Count < 4)
            {
                // uçuş planlaması yapabiliriz.
                flights.Add(flight);
            }
            else
            { // aktarmalı değildir
                if (flights.Count == 0) // 
                {
                    flights.Add(flight);
                }
                else
                {
                    throw new Exception("Aktarmasız uçuş kartında sadece bir ader uçuş bilgisi olabilir");
                }
            }
        }

        /// <summary>
        /// Uçuş kartına uçuş tanımı yapar
        /// Aktarmasız uçuşlarda uçuş kartında en fazla 1 uçuş planlanabilir.
        /// Aktarmalı uçuşlar; Uçuş kartı en fazla 3 aktarma yani 4 adet uçuşa sahip olabilir.
        /// </summary>
        /// <param name="flight"></param>
        public void AddFlight(Flight flight)
        {
            // bugün ve bugünden sonraki günler için bir uçuş planlaması yapılabilir.
            // maksimum 1 ay sonrasına uçuş planlanması yapılabilsin
            // Gün içerisinde bir uçuş planlaması yapılacak ise, 6 saat öncesinde uçuş kartı oluşturulmalıdır.

            TimeSpan departureTime = flight.DepartureDate.TimeOfDay;
            TimeSpan nowTime = DateTime.Now.TimeOfDay;
            bool departureTimeGreaterThanNow = (departureTime.Hours > nowTime.Hours) ? true : false;
            var dateDiff = flight.DepartureDate.Date - DateTime.Now.Date;

            // aynı gün mü dd-mm-yyyy hhMM : 00:00 olduğundan dolayı aynı gün kontrolü yapmış oluruz.
            if (DateTime.Now.Date == flight.DepartureDate.Date)
            {
                // kalkış zamanı şuandan daha geç bir saat mi
                if (departureTimeGreaterThanNow)
                {
                    // uçuşa daha 6 saaten daha az bir zaman varsa 
                    if ((departureTime.Hours - nowTime.Hours) < 6)
                    {
                        throw new Exception("Uçuşa 6 saaten az var uçuş planlamaı yapamazsınız");
                    }
                    else
                    {
                        // uçuş planlaması yapabiliriz.
                        CheckFlightRequest(flight);
                    }
                }
                else
                {
                    throw new Exception("Geçmiş bir tarih için uçuş planlayamazsınız");
                }
            }
            else if (DateTime.Now.Date > flight.DepartureDate.Date) // şuanki tarih kalkış zamanını geçmiş ise
            {
                throw new Exception("Geçmiş tarihli bir uçuş planlayamazsınız");
            }
            else if (dateDiff.Days < 32) // Aylık period içerisinde uçuş planlaması yapılabilir
            {
                // uçuş planlaması yapabiliriz.
                CheckFlightRequest(flight);

            }
            else
            {
                throw new Exception("En fazla 1 aylık period için uçuş planlaması yapabilirsiniz");
            }
        }

        /// <summary>
        /// Daha önceden uçuş kartına aynı para biriminde ve aynı tarifede (bussiness,economy) uçuş fiyatını girmeyi kontrol ettik
        /// Aynı para birimine ve farklı tarifeler birbileri ile aynı fiyat tarifesi uygulanamasın ve bussiness fiyat tarifesi economyden daha fazla olmalıdır. (business 100 TL, economy 100 TL) olmamalıdır.
        ///  FlightTypeCurrency.Count x FlightType.Count adeti kadar farklı fiyat tarifesi uygulanabilir algoritmasını da ekleyelim.
        /// FlightTypeların içerisinde gezip Economy ve Business tarife algoritmasını dinamikleştirelim
        /// </summary>
        /// <param name="flightTypePrice"></param>
        public void AddFlightTypePrice(FlightTypePrice flightTypePrice)
        {
            // girilecek olan fiyat bilgisi daha önce başka bir flightprice tanımlandımı kontrolü yapalım
            var samePriceType = flightTypePrices.Any(x => x.Type == flightTypePrice.Type && x.Currency == flightTypePrice.Currency);
          
            int maximumFlightPriceCount = (Enum.GetNames(typeof(FlightTypeCurrency)).Length) * (Enum.GetNames(typeof(FlightType)).Length);
            int existingFlightPriceCount = flightTypePrices.Count();

            // daha bu kart için uçuş kartı fiyatı girme limitim aşılmadıysa ben bu fiyatı girebilirim
            if (existingFlightPriceCount < maximumFlightPriceCount)
            {
                // daha önceden bu para biriminde ve flightprice tipinde bir kayıt varsa hata ver aynısından sisteme bir daha eklenmesine izin verme
                if (samePriceType)
                {
                    throw new Exception($"Daha önce {flightTypePrice.Type} uçuş tipinde bir kaydı {flightTypePrice.Currency} para birimi cinsinden sisteme girdiniz");
                }
                else
                {
                    // daha önceden uçuş kartına eklediğim fiyat tarifelerinin Rankları üzerinden (ömenlilik derecesi baz alınarak) girilmesini kontrol eden algoritma
                    foreach (string flightTypePriceName in Enum.GetNames(typeof(FlightType)))
                    {
                        var existingFlightTypePrice = flightTypePrices.Find(x => x.Type == flightTypePriceName && x.Currency == flightTypePrice.Currency);
                        // sisteme daha önceden bir fiyat tanımı yapıldıysa
                        if(existingFlightTypePrice != null)
                        {
                            // enumdaki elemanların value değer karşılıkllarını bulan algoritma. Bu rank değerini getirir.
                            int newPriceTypeRank = (int)(Enum.Parse(typeof(FlightType), flightTypePrice.Type));
                            int existingPriceTypeRank = (int)(Enum.Parse(typeof(FlightType), existingFlightTypePrice.Type));

                            // Economy Business Case
                            if (existingPriceTypeRank < newPriceTypeRank)
                            {

                                if(existingFlightTypePrice.ListPrice >= flightTypePrice.ListPrice)
                                {
                                    

                                    throw new Exception($"{flightTypePrice.Type.ToString()} tarifesi {existingFlightTypePrice.Type.ToString()} tarifesinin fiyatını aşmamalıdır!");
                                }
                            }
                            else
                            {
                                // Business Econmy Case
                                if(existingFlightTypePrice.ListPrice <= flightTypePrice.ListPrice)
                                {
                                    throw new Exception($"{flightTypePrice.Type.ToString()} tarifesin in fiyatı {existingFlightTypePrice.Type.ToString()} tarifesinin fiyatından daha yüksek olmalıdır!");
                                }
           
                            }
                        }
   
                    }

                    // hata olmadıoğı durumda foreach bitince kayıt girdik
                    flightTypePrices.Add(flightTypePrice);
                }

            }
            else
            {
                throw new Exception("Bu uçuş kartı için tüm fiyat tarifesi bilgilerini girdiniz!");
            }
        }
    }
}
