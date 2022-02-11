using NBuyWeFly.Models;
using NBuyWeFly.Models.Flights;
using System;
using System.Collections.Generic;

namespace NBuyWeFly
{
    class Program
    {
        static void Main(string[] args)
        {

            var from = new Airport(name: "SABİHA GÖKÇEN", shortCode: "SAW", cityName: "İstanbul");
            var to = new Airport(name: "ADNAN MENDERES", shortCode: "ADB", cityName: "İzmir");


            // Test Case 1: aktarmasız uçuş kartı case
            #region TestCase1

            /*

          var departureDate = DateTime.Now.AddDays(5);
          var arrivalDate = DateTime.Now.AddDays(5).AddMinutes(90);

          Flight f1 = new Flight(from,to, departureDate, arrivalDate);
          Flight f2 = new Flight(from, to, departureDate.AddHours(2), arrivalDate.AddHours(3));


          
          // Test Case 1 : aktarmasız uçuşlara 2 tane uçuş bilgisi girememiz lazım
          FlightCard card1 = new FlightCard(indirect: false);
          card1.AddFlight(f1);
          card1.AddFlight(f2);

          */

            #endregion

            // Test Case 2: aynı gün 6 saat sonrası için uçuş kartı tanımlama case
            #region TestCase2

            /*
            FlightCard card2 = new FlightCard(indirect: false);
            var departureDate2 = DateTime.Now.AddHours(13);
            var arrivalDate2 = DateTime.Now.AddHours(15);
            Flight f2 = new Flight(from, to, departureDate2, arrivalDate2);
            card2.AddFlight(f2);

            */

            #endregion


            // Test Case 3: 1.5 ay sonrasına uçuş kartı tanımlama case (Bu eklenememeli)
            #region TestCase3

            /*
            FlightCard card3 = new FlightCard(indirect: false);
            var departureDate3 = DateTime.Now.AddMonths(2);
            var arrivalDate3 = DateTime.Now.AddMonths(2).AddHours(15);
            Flight f3 = new Flight(from, to, departureDate3, arrivalDate3);
            card3.AddFlight(f3);

            */

            #endregion

            // Test Case 4: aynı gün 6 saaten daha az bir zaman için
            #region TestCase4
            /*

            FlightCard card4 = new FlightCard(indirect: false);
            var departureDate4 = DateTime.Now.AddHours(3);
            var arrivalDate4 = DateTime.Now.AddHours(5);
            Flight f4 = new Flight(from, to, departureDate4, arrivalDate4);
            card4.AddFlight(f4);

            */

            #endregion

            // TestCase 5: Geçmiş tarihli uçuş planlanabiliyor mu?
            #region TestCase5
            /*
            FlightCard card5 = new FlightCard(indirect: false);
            var departureDate5 = DateTime.Now.AddHours(-3);
            var arrivalDate5 = DateTime.Now.AddHours(-5);
            Flight f5 = new Flight(from, to, departureDate5, arrivalDate5);
            card5.AddFlight(f5);
            */
            #endregion

            // Test Case 6: aktarmalı uçuş case
            #region Case6

            //FlightCard card6 = new FlightCard(indirect: true);
            //var departureDate6 = DateTime.Now.AddHours(9);
            //var arrivalDate6 = DateTime.Now.AddHours(10);

            //var departureDate61 = DateTime.Now.AddHours(11);
            //var arrivalDate61 = DateTime.Now.AddHours(13);

            //Flight f6 = new Flight(from, to, departureDate6, arrivalDate6);
            //Flight f61 = new Flight(from, to, departureDate61, arrivalDate61);
            //card6.AddFlight(f6);
            //card6.AddFlight(f61);
            #endregion


            // HashSet aynı instance referansına bakar referance type için, valuetype değere bakar.
            // Test Case 7: planlanan uçu sayısı 4 den fazla olduğunda
            #region Case7

            /*

            FlightCard card7 = new FlightCard(indirect: true);
            var departureDate7 = DateTime.Now.AddHours(9);
            var arrivalDate7 = DateTime.Now.AddHours(10);

            var departureDate71 = DateTime.Now.AddHours(11);
            var arrivalDate71 = DateTime.Now.AddHours(13);

            var departureDate72 = DateTime.Now.AddHours(11);
            var arrivalDate72 = DateTime.Now.AddHours(13);

            var departureDate73 = DateTime.Now.AddHours(11);
            var arrivalDate73 = DateTime.Now.AddHours(13);

            var departureDate74 = DateTime.Now.AddHours(11);
            var arrivalDate74 = DateTime.Now.AddHours(13);

            Flight f7 = new Flight(from, to, departureDate7, arrivalDate7);
            Flight f71 = new Flight(from, to, departureDate71, arrivalDate71);
            Flight f72 = new Flight(from, to, departureDate72, arrivalDate72);
            Flight f73 = new Flight(from, to, departureDate73, arrivalDate73);
            Flight f74 = new Flight(from, to, departureDate74, arrivalDate74);

            card7.AddFlight(f7);
            card7.AddFlight(f71);
            card7.AddFlight(f72);
            card7.AddFlight(f73);
            card7.AddFlight(f74);

            */

            #endregion

            // Test Case 8: aynı tarife aynı para birimi girilebiliyor mu? veya farklı currency gidilebiliyor mu
            #region Case8
            /*
            FlightCard card8 = new FlightCard(indirect: false);
            var departureDate8 = DateTime.Now.AddHours(10);
            var arrivalDate8 = DateTime.Now.AddHours(15);
            Flight f8 = new Flight(from, to, departureDate8, arrivalDate8);
            card8.AddFlightTypePrice(FlightTypePrice.CreateInstance(FlightType.Business.ToString(), FlightTypeCurrency.TL.ToString(), 100));
            card8.AddFlightTypePrice(FlightTypePrice.CreateInstance(FlightType.Business.ToString(), FlightTypeCurrency.Dolar.ToString(), 78));
            //card8.AddFlightTypePrice(FlightTypePrice.CreateInstance(FlightType.Business.ToString(), FlightTypeCurrency.TL.ToString(), 78));
            card8.AddFlight(f8);

            */
            #endregion

            /// Test Case 9 Business kaydı atalım 150 TL olsun arkasında 170 lik Economy alarak ekleme yapalım
            #region Case9
            /*
            FlightCard card9 = new FlightCard(indirect: false);
            var departureDate9 = DateTime.Now.AddHours(15);
            var arrivalDate9 = DateTime.Now.AddHours(20);
            Flight f9 = new Flight(from, to, departureDate9, arrivalDate9);
            card9.AddFlightTypePrice(FlightTypePrice.CreateInstance(type:FlightType.Business.ToString(), currency: FlightTypeCurrency.TL.ToString(), 150 ));
            card9.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Economy.ToString(), currency: FlightTypeCurrency.TL.ToString(), 170));
            */
            #endregion
           
            // uçuş kartına 6 dan fazla fiyat politikası uygulanamasın (Econpomy,Business) (TL,Dolar,Euro) olarak 6 farklı adet değer girip 7. kaydı test edelim
            #region Case10
            FlightCard card10 = new FlightCard(indirect: false);
            var departureDate10 = DateTime.Now.AddHours(15);
            var arrivalDate10 = DateTime.Now.AddHours(20);
            Flight f10 = new Flight(from, to, departureDate10, arrivalDate10);
            card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Business.ToString(), currency: FlightTypeCurrency.TL.ToString(), 150));
            card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Business.ToString(), currency: FlightTypeCurrency.Dolar.ToString(), 150));
            card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Business.ToString(), currency: FlightTypeCurrency.Euro.ToString(), 150));

            card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Economy.ToString(), currency: FlightTypeCurrency.TL.ToString(), 100));
            card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Economy.ToString(), currency: FlightTypeCurrency.Dolar.ToString(), 150));
            card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Economy.ToString(), currency: FlightTypeCurrency.Euro.ToString(), 100));

            //card10.AddFlightTypePrice(FlightTypePrice.CreateInstance(type: FlightType.Economy.ToString(), currency: FlightTypeCurrency.TL.ToString(), 90));

            #endregion

            // Test Case 8: Kalkış varış zamanı arasında eksi bir değer olmasın case

            // Test Case 9:  Aktarmalı uçuşlarda varış kalkış zamanları arasındaki farkı kontrol edelim

            // Test Case 10: Aktarmalı uçuşlarda From: Istanbul To: Paris sonraki ise From Paris to Berlin olduğunu varsayarsak. İlkinin To ile aktarmanın From aynı seçilmelidir.

            // Test Case 10: FlightCard Fligt eklerken Company kontrolü yapalım. Company boş giderse FlightNumber doğru olmaz, flight carda company bilgisi gösteremeyiz.




            //var f = new Company();
            //f.Flights.Add(new Flight());
            Console.WriteLine("Hello World!");
        }
    }
}
