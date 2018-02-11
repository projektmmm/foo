using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();

            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:54736/");
                client.DefaultRequestHeaders.Accept.Clear(); //odstraneni predeslych pozadovanych formatu odpovedi
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //chci dostat zpet json

                Console.WriteLine("GET");
                HttpResponseMessage response = await client.GetAsync("api/person/5");

                //github test
                if (response.IsSuccessStatusCode)
                {
                    Person person = await response.Content.ReadAsAsync<Person>();
                    Console.WriteLine($"{person.Id}\t{person.Name}\t{person.Surname}\t{person.Age}");
                }
            }
        }
    }
}
