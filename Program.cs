using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace UniversalAPI.Example
{
    class Program
    {
        static void Main()
        {
            //1. Creating API requests
            List<Dictionary<string, dynamic>> requests = new List<Dictionary<string, dynamic>>
            {
                new Dictionary<string, dynamic>
                {
                    { "Request", "wallet" },
                    { "Id", 3 },
                    { "Owner", "0x3a31ee5557c9369c35573496555b1bc93553b553" }
                },
                new Dictionary<string, dynamic>
                {
                    { "Request", "mysignup" },
                    { "Id", 3 },
                    { "address", "0x3a31ee5557c9369c35573496555b1bc93553b553" }
                },
                new Dictionary<string, dynamic>
                {
                    { "Request", "tokenbalanse" },
                    { "Id", 1 }
                },
                new Dictionary<string, dynamic>
                {
                    { "Request", "tokenbalanse" }
                }
            };
            Environment.SetEnvironmentVariable("UniversalAPI.ConnectionString", ConnectionString.ConnectionToApi);


            var optionsBuilder = new DbContextOptionsBuilder<APIContext>();
            var options = optionsBuilder
                .UseSqlServer(ConnectionString.ConnectionToApi).Options;

            using (var context = new APIContext(options))
            {
                //2. Create api obj
                APIClient api = new APIClient(ConnectionString.ConnectionToData);

                // By default, the console logging option is enabled
                //api.ConsoleLogEnabled = false;

                foreach (var data in requests)
                {
                    //3. Create request
                    var request = JsonConvert.SerializeObject(data);

                    //4. Invoke request
                    string result = api.InvokeRequest(request, context);
                    //Console.WriteLine(result);
                }
            }
            Console.ReadLine();
        }
    }
}
