using HiveAPI.CS;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hive_Vote
{
    internal class Program
    {

        #region Variables
        private const string hiveUser = "your hive username without the @";
        private const string postingKey = "your posting key here";
        #endregion

        private static string hiveVote(string voter, string author, string permlink, short weight)
        {
            HttpClient oHTTP = new HttpClient();
            CHived oHived = new CHived(oHTTP, "https://anyx.io");

            COperations.vote oVote = new COperations.vote
            {
                voter = voter,
                author = author,
                permlink = permlink,
                weight = weight
            };

            try
            {
                string txid = oHived.broadcast_transaction(
                    new object[] { oVote },
                    new string[] { postingKey }
                    );

                return txid;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        static void Main(string[] args)
        {
            string response = hiveVote(hiveUser, "chaoscommander", "broadcasting-votes-on-the-hive-blockchain-using-c-and-hivenet-library", 100);
            Console.WriteLine(response);
            Console.ReadLine(); //to prevent the console from closing right away.
        }
    }
}
