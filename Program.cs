using System;
using System.Collections.Generic;
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
                    { "Id", 3 },
                    { "address", "0x3a31ee5557c9369c35573496555b1bc93553b553" }
                },
                new Dictionary<string, dynamic>
                {
                    { "Id", 3 },
                    { "Owner", "0x3a31ee5557c9369c35573496555b1bc93553b553" }
                },
                new Dictionary<string, dynamic>
                {
                    { "Id", 1 }
                },
                new Dictionary<string, dynamic> { }     // Request without parameters
            };

            //2. Setting requets
            List<APIRequestSettings> requestSettings = new List<APIRequestSettings>
            {
                new APIRequestSettings {
                    SelectedTables = "SignUp, LeaderBoard",
                    SelectedColumns = "SignUp.PoolId, LeaderBoard.Rank, LeaderBoard.Owner, LeaderBoard.Amount",
                    JoinCondition = "SignUp.Address = LeaderBoard.Owner"
                },
                new APIRequestSettings {
                    SelectedTables = "Wallets",
                    SelectedColumns = "*"
                },
                new APIRequestSettings {
                    SelectedTables = "TokenBalances",
                    SelectedColumns = "Token, Owner, Amount"
                },
                new APIRequestSettings {
                    SelectedTables = "TokenBalances",
                    SelectedColumns = "Token, Owner, Amount"
                }
            };

            // By default, the console logging option is enabled
            //APIClient.ConsoleLogEnabled = false;

            for (int i = 0; i < requests.Count; i++)
            {
                //3. Create request
                var request = JsonConvert.SerializeObject(requests[i]);

                //4. Invoke request
                string result = APIClient.InvokeRequest(request, requestSettings[i], ConnectionString.ConnectionToData);
            }
            Console.ReadLine();
        }
    }
}
