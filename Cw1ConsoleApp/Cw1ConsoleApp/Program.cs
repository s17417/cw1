using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1ConsoleApp
{
    public class Program
    {
      
        public static async Task Main(string[] args)
        {
            var url = args.Length > 0 ? args[0] : "http://www.pja.edu.pl";
            //var httpClient = new HttpClient();   //to jest to samo co HttpClient httpClient
            var client = new HttpClient();
            var result= await client.GetAsync(url);
            
            if (result.IsSuccessStatusCode)
            {
                string htmlContent = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }

            }

        }
    }
}
