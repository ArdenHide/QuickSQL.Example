using System;
using Microsoft.EntityFrameworkCore;
using QuickSQL.Example.DBModel;

namespace QuickSQL.Example
{
    class Program
    {
        static void Main()
        {
            // By default, the option to output to the console is disabled
            QuickSql.ConsoleOutputEnabled = true;

            // Context where the data comes from
            var contextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer(ConnectionString.ConnectionToData).Options;

            using (var context = new DataContext(contextOptions))
            {
                Request signUp = new Request
                {
                    SelectedTables = "SignUp, LeaderBoard",
                    SelectedColumns = "SignUp.PoolId, LeaderBoard.Rank, LeaderBoard.Owner, LeaderBoard.Amount",
                    WhereCondition = "SignUp.Id = 3, SignUp.Address = '0x3a31ee5557c9369c35573496555b1bc93553b553'",
                    JoinCondition = "SignUp.Address = LeaderBoard.Owner"
                };
                QuickSql.InvokeRequest(signUp, context);
                //  The example displays the following output:
                //      QuickSql started...
                //      Received request:
                //          SelectedTables: SignUp, LeaderBoard
                //          SelectedColumns: SignUp.PoolId, LeaderBoard.Rank, LeaderBoard.Owner, LeaderBoard.Amount
                //          WhereCondition: SignUp.Id = 3, SignUp.Address = '0x3a31ee5557c9369c35573496555b1bc93553b553'
                //          JoinCondition: SignUp.Address = LeaderBoard.Owner
                //
                //      QuickSql started create SQL query...
                //      Created query: SELECT SignUp.PoolId, LeaderBoard.Rank, LeaderBoard.Owner, LeaderBoard.Amount FROM SignUp INNER JOIN LeaderBoard ON SignUp.Address = LeaderBoard.Owner WHERE SignUp.Id = 3 AND SignUp.Address = '0x3a31ee5557c9369c35573496555b1bc93553b553' FOR JSON PATH
                //
                //      QuickSql started received data...
                //      Received data: [{ "PoolId":3,"Rank":"3","Owner":"0x3a31ee5557c9369c35573496555b1bc93553b553","Amount":"250.02109769151781894"}]
                //
                //      QuickSql finished...
                //      Program execution time: YOUR_EXECUTION_TIME

                Request wallets = new Request
                {
                    SelectedTables = "wallets",
                    SelectedColumns = "*",
                    WhereCondition = "Id = 3, Owner = '0x3a31ee5557c9369c35573496555b1bc93553b553'"
                };
                QuickSql.InvokeRequest(wallets, context);
                //  The example displays the following output:
                //      QuickSql started...
                //      Received request:
                //          SelectedTables: wallets
                //          SelectedColumns: *
                //          WhereCondition: Id = 3, Owner = '0x3a31ee5557c9369c35573496555b1bc93553b553'
                //
                //      QuickSql started create SQL query...
                //      Created query: SELECT* FROM wallets WHERE Id = 3 AND Owner = '0x3a31ee5557c9369c35573496555b1bc93553b553' FOR JSON PATH
                //
                //      QuickSql started received data...
                //      Received data: [{ "Id":3,"Owner":"0x3a31ee5557c9369c35573496555b1bc93553b553"}]
                //
                //      QuickSql finished...
                //      Program execution time: YOUR_EXECUTION_TIME

                Request tokenBalances1 = new Request
                {
                    SelectedTables = "TokenBalances",
                    SelectedColumns = "Token, Owner, Amount",
                    WhereCondition = "Id = 1"
                };
                QuickSql.InvokeRequest(tokenBalances1, context);
                //  The example displays the following output:
                //      QuickSql started...
                //      Received request:
                //          SelectedTables: TokenBalances
                //          SelectedColumns: Token, Owner, Amount
                //          WhereCondition: Id = 1
                //
                //      QuickSql started create SQL query...
                //      Created query: SELECT Token, Owner, Amount FROM TokenBalances WHERE Id = 1 FOR JSON PATH
                //
                //      QuickSql started received data...
                //      Received data: [{ "Token":"ADH","Owner":"0x1a01ee5577c9d69c35a77496565b1bc95588b521","Amount":"400"}]
                //
                //      QuickSql finished...
                //      Program execution time: YOUR_EXECUTION_TIME

                Request tokenBalances2 = new Request
                {
                    SelectedTables = "TokenBalances",
                    SelectedColumns = "Token, Owner, Amount"
                };
                QuickSql.InvokeRequest(tokenBalances2, context);
                //  The example displays the following output:
                //      QuickSql started...
                //      Received request:
                //          SelectedTables: TokenBalances
                //          SelectedColumns: Token, Owner, Amount
                //
                //      QuickSql started create SQL query...
                //      Created query: SELECT Token, Owner, Amount FROM TokenBalances FOR JSON PATH
                //
                //      QuickSql started received data...
                //      Received data: [{ "Token":"ADH","Owner":"0x1a01ee5577c9d69c35a77496565b1bc95588b521","Amount":"400"},{ "Token":"Poolz","Owner":"0x2a01ee5557c9d69c35577496555b1bc95558b552","Amount":"300"},{ "Token":"ETH","Owner":"0x3a31ee5557c9369c35573496555b1bc93553b553","Amount":"200"},{ "Token":"BTH","Owner":"0x4a71ee5577c9d79c37577496555b1bc95558b554","Amount":"100"}]
                //
                //      QuickSql finished...
                //      Program execution time: YOUR_EXECUTION_TIME
            }
            Console.ReadLine();
        }
    }
}
