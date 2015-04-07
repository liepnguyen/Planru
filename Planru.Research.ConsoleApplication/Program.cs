using Planru.Crosscutting.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planru.Crosscutting.Logging;

namespace Planru.Research.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Log4NetLogger();
            logger.Fatal("write a fantal error");
            Console.ReadKey();
        }
    }
}
