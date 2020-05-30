using ConsoleBrontoLeagues.Models;
using ConsoleBrontoLeagues.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleBrontoLeagues
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPlayers();
        }
        public static void GetPlayers()
        {
            try
            {
                BrontoResult ObjBrontoJazz = new BrontoResult();
                ObjBrontoJazz = new GenericHttpJson().PostEventResponse<BrontoResult, BrontoResult>(ObjBrontoJazz, "https://localhost:44346/api/Bronto/LeaguesProccessJazz ", " ");
                Console.WriteLine("=========================Jazz SportsBook=======================");
                Console.WriteLine(ObjBrontoJazz.ToString());
                Console.WriteLine("==========================ABC Islands==========================");
                BrontoResult ObjBrontoABC = new BrontoResult();
                ObjBrontoABC = new GenericHttpJson().PostEventResponse<BrontoResult, BrontoResult>(ObjBrontoABC, "https://localhost:44346/api/Bronto/LeaguesProccessABC ", " ");
                Console.WriteLine(ObjBrontoABC.ToString());
                Console.WriteLine("==========================Loose lines==========================");
                BrontoResult ObjBrontoLooseLines = new BrontoResult();
                ObjBrontoLooseLines = new GenericHttpJson().PostEventResponse<BrontoResult, BrontoResult>(ObjBrontoLooseLines, "https://localhost:44346/api/Bronto/LeaguesProccessLooseLines ", " ");
                Console.WriteLine(ObjBrontoLooseLines.ToString());
                Thread.Sleep(5000);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
