using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace BitCoinCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BitCoinRate currentBitcoin = GetRates();
            Console.WriteLine($"current rate: {currentBitcoin.bpi.EUR.code} {currentBitcoin.bpi.EUR.rate_float}");
            Console.WriteLine("Calculate in: EUR/USD/GBP");
            string UserChoice = Console.ReadLine();
            Console.WriteLine("ENTER THE AMOUNT OF BITCOINS");
            float userCoins = float.Parse(Console.ReadLine());
            float currentRate = 0;

                if(UserChoice == "EUR")
            {
                currentRate = currentBitcoin.bpi.EUR.rate_float;
            }
                else if(UserChoice == "Usd")
            {
                currentRate = currentBitcoin.bpi.EUR.rate_float;
            }
                else if(UserChoice == "GBP")
            {
                currentRate = currentBitcoin.bpi.EUR.rate_float;
            }
            float result = currentRate * userCoins;
            Console.WriteLine($"your bitcoins are worth {result} {UserChoice}");
        }
        public static BitCoinRate GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponese = request.GetResponse();
            var webStream = webResponese.GetResponseStream();

            BitCoinRate bitcoindata;

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoindata = JsonConvert.DeserializeObject<BitCoinRate>(response);
            }
            return bitcoindata;
        }
    }
}
