using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBrokerAPI
{
    public class Program
    {
		public static void Main()
		{
			const string url = @"https://api.stagingeb.com/v1/properties";
			const string apiKey = "l7u502p8v46ba3ppgvj5y2aad50lb9";

			var task = Task.Run(() => getPropeties(url, apiKey));
			task.Wait();
			var result = task.Result;

			foreach (dynamic p in result.content) {
				Console.WriteLine(p.title);
			}

			//Console.WriteLine("Presione una tecla para finalizar");
			//Console.ReadLine();
		}


		static async Task<dynamic> getPropeties(string url, string apiKey)
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri(url);
			client.DefaultRequestHeaders.Add("accept", "application/json");
			client.DefaultRequestHeaders.Add("X-Authorization", apiKey);
			var response = await client.GetAsync("");
			dynamic result = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

			return result;
		}
	}
}
