using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetBattleBackEnd.Models;

namespace PetBattleBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetAccesTokenAsync().Wait();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static async Task SetAccesTokenAsync() {
            HttpClient client = new HttpClient();
            string baseAddress = @"https://eu.battle.net/oauth/token";

            string grant_type = "client_credentials";
            string client_id = "f4dabd6aa2974b6799c65808adeec752";
            string client_secret = "R7qlPfU8K7oM5VwttHdva9LwfINLUitL";

            var form = new Dictionary<string, string>
                {
                    {"grant_type", grant_type},
                    {"client_id", client_id},
                    {"client_secret", client_secret},
                };

            HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            Token token = JsonConvert.DeserializeObject<Token>(jsonContent);
            Singleton.AccessToken = token.access_token;

            var response = await client.GetAsync($"https://eu.api.blizzard.com/wow/pet/?locale=en_US&access_token={token.access_token}");
            jsonContent = await response.Content.ReadAsStringAsync();
            var root = JsonConvert.DeserializeObject<Root>(jsonContent);
            Singleton.Pets = root.Pets;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    public class Root {
        public List<Pet> Pets { get; set; }
    }
}
